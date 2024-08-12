using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using SeagullSama.Manager;
using SeagullSama.Utility;
using SeagullSama;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;
using Gizmos = Popcron.Gizmos;

namespace SeagullSama.Controller
{
    public class SeagullAbility : IAbility
    {
        SeagullController _seagullController;

        public string AbilityName => GetType().Name;

        public virtual void Activate()
        {
            throw new NotImplementedException();
        }

        public virtual void Deactivate()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AbilityName", AbilityName);
            info.AddValue("SeagullController", (object)_seagullController);
        }
    }

    public class SeagullController : MonoBehaviour
    {
        private static SeagullController _instance;

        public static SeagullController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SeagullController>();
                }

                return _instance;
            }
        }


        #region 控制器配置

        [Header("Configuration"), Tooltip("最大移动速度")]
        public float moveSpeedMax = 5.0f;

        [Tooltip("移动加速度")]
        public float moveSpeedAcceleration = 5.0f;

        [Tooltip("减速速度")]
        public float moveSpeedDeceleration = 5.0f;

        [Tooltip("旋转速度")]
        public float rotateSpeed = 5.0f;

        [Tooltip("头部组件")]
        public Transform headTransform;

        [Tooltip("头部旋转角度上限")]
        public float headRotationMax = 90.0f;

        [Tooltip("头部旋转角度下限")]
        public float headRotationMin = -90.0f;

        [Tooltip("跳跃力量")]
        public float jumpForce = 5.0f;

        [Tooltip("吞噬平面中心点")]
        public Transform swallowCenter;

        [Tooltip("吞噬平面半径")]
        public float swallowRadius = 5.0f;

        [Tooltip("吞噬范围深度")]
        public float swallowDepth = 5.0f;

        [Tooltip("吞噬强度")]
        public float swallowForce = 10.0f;

        [Tooltip("连续跳跃次数")]
        public int maxJumpCount = 1;

        #endregion


        public OnLandDetector onLandDetector;

        private IDebugUtility _debugUtility;
        private IAbilityManager _abilityManager;
        private SeagullInput _inputActions;

        private InputAction _jumpInput;
        private InputAction _swallowInput;
        private InputAction _movementInput;
        private InputAction _mouseLocationInput;

        private Vector2 _currentVelocity = Vector2.zero;
        private float _targetBodyYaw = 0.0f;
        private bool _isMoving = false;
        private bool _isJumping = false;
        private int _currentJumpCount = 0;
        private bool _isSwallowing = false;

        private Rigidbody _rigidbody;

        private Coroutine _swallowCoroutine;

        private void Start()
        {
            _inputActions = SeagullSama.Instance.GetUtility<IInputUtility>().GetInputActions();

            _movementInput = _inputActions.CharacterActions.MovementInput;
            _mouseLocationInput = _inputActions.CharacterActions.MouseLocation;

            _jumpInput = _inputActions.CharacterActions.JumpAction;
            _jumpInput.performed += StartJumping;

            _swallowInput = _inputActions.CharacterActions.SwallowAction;
            _swallowInput.performed += StartSwallowing;

            _rigidbody = GetComponent<Rigidbody>();
            if (_rigidbody == null)
            {
                Debug.LogError("Rigidbody is not set");
            }

            _debugUtility = SeagullSama.Instance.GetUtility<IDebugUtility>();
            if (_debugUtility == null)
            {
                Debug.LogError("DebugUtility is not set");
            }

            _abilityManager = SeagullSama.Instance.GetManager<IAbilityManager>();
            if (_abilityManager == null)
            {
                Debug.LogError("AbilityManager is not set");
            }

            if (swallowCenter == null)
            {
                Debug.LogError("SwallowCenter is not set");
            }

            onLandDetector.OnLand += EndJumping;

        }

        private void OnDestroy()
        {
            _jumpInput.performed -= StartJumping;
            _swallowInput.performed -= StartSwallowing;
        }

        public void StartJumping(InputAction.CallbackContext context)
        {
            if (_currentJumpCount >= maxJumpCount)
            {
                return;
            }

            _isJumping = true;
            _currentJumpCount++;

            // 根据跳跃速度跳起来(设置一个向上的冲量)
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void EndJumping()
        {
            if (!_isJumping)
            {
                return;
            }

            _isJumping = false;
            _currentJumpCount = 0;
        }

        private void PickupItem(GameObject item)
        {
            if (item == null || item == gameObject)
            {
                return;
            }

            IPickableItem pickableItem = item.GetComponent<IPickableItem>();
            if (pickableItem != null)
            {
                switch (pickableItem.PickableItemType)
                {
                    case EPickableItemType.AbilityStone:
                        string abilityName = pickableItem.GetItem() as string;

                        // 装备技能
                        _abilityManager.EquipAbility(abilityName);

                        break;
                    case EPickableItemType.GeneralItem:
                        Debug.Log("Picked up a general item");
                        break;
                    default:
                        break;
                }
            }

            Destroy(item);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isSwallowing)
            {
                // 判断是否实现了 IPickableItem 接口
                if (collision.gameObject.GetComponent<IPickableItem>() != null)
                {
                    PickupItem(collision.gameObject);
                }
            }
        }

        private void Update()
        {
            UpdateRotation();
            UpdateMovement();

            UpdateDebugGizmos();
        }

        private void UpdateRotation()
        {
            // 读取鼠标位置
            Vector2 mouseScreenLocation = _mouseLocationInput.ReadValue<Vector2>();

            // 当前身体的旋转角度
            float currentBodyYaw = transform.rotation.eulerAngles.y;

            // 做射线检测并获取鼠标点击位置
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenLocation);
            Vector3 targetPosition = Vector3.zero;
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPosition = hit.point;

                // 根据射线碰撞位置计算旋转角度
                targetPosition.y = transform.position.y;
                Vector3 direction = targetPosition - transform.position;
                float targetyaw = Quaternion.LookRotation(direction).eulerAngles.y;

                // 根据头部旋转限制设置旋转
                float targetHeadYaw = Mathf.DeltaAngle(currentBodyYaw, targetyaw);

                if (targetHeadYaw > headRotationMin && targetHeadYaw < headRotationMax)
                {
                    // 不用转身体，只转头部
                    headTransform.localRotation = Quaternion.Euler(0, targetHeadYaw, 0);
                }
                else
                {
                    if (targetHeadYaw > headRotationMax)
                    {
                        headTransform.localRotation = Quaternion.Euler(0, headRotationMax, 0);
                        if (!_isMoving)
                        {
                            // 如果不运动,则转动身体使得头部朝向鼠标方向
                            _targetBodyYaw = (targetyaw - headRotationMax + 360) % 360;
                        }
                    }
                    else
                    {
                        headTransform.localRotation = Quaternion.Euler(0, headRotationMin, 0);
                        if (!_isMoving)
                        {
                            // 如果不运动,则转动身体使得头部朝向鼠标方向
                            _targetBodyYaw = (targetyaw - headRotationMin + 360) % 360;
                        }
                    }
                }
            }

            // 非跳跃状态下,转动身体
            if (!_isJumping)
            {
                // 转动身体,使得海鸥头朝向鼠标方向
                float temp = currentBodyYaw;
                currentBodyYaw = (Mathf.LerpAngle(currentBodyYaw, _targetBodyYaw, Time.deltaTime * rotateSpeed)) % 360;
                transform.rotation = Quaternion.Euler(0, currentBodyYaw, 0);
            }
        }

        private void UpdateMovement()
        {
            if (!_isJumping)
            {
                // 非跳跃状态下,根据输入加速减速
                Vector2 movementValue = _movementInput.ReadValue<Vector2>();

                if (movementValue.magnitude > 0.1f)
                {
                    // 加速移动
                    _currentVelocity = Vector2.Lerp(
                        _currentVelocity,
                        movementValue * moveSpeedMax,
                        Time.deltaTime * moveSpeedAcceleration);
                }
                else
                {
                    // 减速
                    _currentVelocity = Vector2.Lerp(
                        _currentVelocity,
                        Vector2.zero,
                        Time.deltaTime * moveSpeedDeceleration);
                }
            }

            Vector3 moveVector = new Vector3(_currentVelocity.x, 0, _currentVelocity.y) * Time.deltaTime;

            transform.Translate(moveVector, Space.World);

            // 如果在运动,则缓慢转动身体使得身体朝向运动方向
            if (_currentVelocity.magnitude > 0.1f)
            {
                // 根据movementDirection 计算运动朝向yaw
                float moveYaw = Mathf.Atan2(_currentVelocity.x, _currentVelocity.y) * Mathf.Rad2Deg;
                _targetBodyYaw = Mathf.LerpAngle(_targetBodyYaw, moveYaw, Time.deltaTime * rotateSpeed);
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }

        }

        // 吞噬技能是核心技能,单独作为主角的一部分来处理
        private void StartSwallowing(InputAction.CallbackContext context)
        {
            if (_isSwallowing)
            {
                Debug.Log("Already Swallowing...");
                return;
            }

            // 使用协程来处理吞噬技能
            _swallowCoroutine = StartCoroutine(SwallowCoroutine());
            _isSwallowing = true;
        }

        IEnumerator SwallowCoroutine()
        {
            float timer = 0.0f;

            while (_swallowInput.IsPressed())
            {
                Debug.Log("Swallowing... + " + timer);
                timer += Time.deltaTime;

                // 吸引力中心
                Vector3 center = swallowCenter.position;

                // 向前方扫描一个范围
                RaycastHit[] raycastHits = Physics.SphereCastAll(
                    swallowCenter.position, swallowRadius,
                    headTransform.forward, swallowDepth);

                foreach (RaycastHit hit in raycastHits)
                {
                    GameObject hitObject = hit.collider.gameObject;

                    if (hitObject == gameObject)
                    {
                        continue;
                    }

                    Rigidbody hitRigidbody = hitObject.GetComponent<Rigidbody>();
                    if (hitRigidbody)
                    {
                        // 向中心吸引
                        Vector3 direction = center - hitObject.transform.position;
                        hitRigidbody.AddForce(direction.normalized * swallowForce);

                    }

                    // PickupItem(hitObject);
                }

                yield return null;
            }

            _isSwallowing = false;
            yield return null;
        }

        private void UpdateDebugGizmos()
        {
            if (_isSwallowing)
            {
                Gizmos.Material = _debugUtility.GetGizmosMaterial(0);
            }
            else
            {
                Gizmos.Material = _debugUtility.GetGizmosMaterial(1);
            }


            // 绘制吞噬范围
            Vector3 center = swallowCenter.position;
            Vector3 forward = headTransform.forward;
            Vector3 right = headTransform.right;
            Vector3 up = headTransform.up;

            // 吞噬平面
            Vector3 TopPoint = center + up * swallowRadius;
            Vector3 BottomPoint = center - up * swallowRadius;
            Vector3 LeftPoint = center - right * swallowRadius;
            Vector3 RightPoint = center + right * swallowRadius;

            // 吞噬深度终点
            Gizmos.Sphere(center, swallowRadius);
            Gizmos.Sphere(center + forward * swallowDepth, swallowRadius);
            Gizmos.Line(TopPoint, TopPoint + forward * swallowDepth);
            Gizmos.Line(BottomPoint, BottomPoint + forward * swallowDepth);
            Gizmos.Line(LeftPoint, LeftPoint + forward * swallowDepth);
            Gizmos.Line(RightPoint, RightPoint + forward * swallowDepth);
        }
    }
}