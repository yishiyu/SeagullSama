using System;
using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using SeagullSama.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SeagullSama.Controller
{
    public class CameraController : MonoBehaviour
    {
        #region 相机配置

        [Header("Configuration"), Tooltip("相机焦点目标列表")]
        public List<Transform> focusTargetList = new List<Transform>();

        [Tooltip("相机移动速度")]
        public float cameraMoveSpeed = 5.0f;

        [Tooltip("相机旋转速度")]
        public float cameraRotateSpeed = 5.0f;

        [Tooltip("相机俯视角度")]
        public float cameraPitchAngle = 45.0f;

        [Tooltip("相机最大俯视角度")]
        public float cameraMaxPitchAngle = 85.0f;

        [Tooltip("相机最小俯视角度")]
        public float cameraMinPitchAngle = 5.0f;

        [Tooltip("相机距离")]
        public float cameraDistance = 15.0f;

        [Tooltip("相机最大高度")]
        public float cameraMaxDistance = 30.0f;

        [Tooltip("相机最小高度")]
        public float cameraMinDistance = 5.0f;

        #endregion


        private IGameStateManager _gameStateManager;
        private SeagullInput _inputActions;
        private InputAction _cameraZoomInput;
        private InputAction _cameraRotateYaw;
        private InputAction _cameraRotatePitch;


        #region 相机内部状态

        // 当前焦点目标
        int _focusCurrentIndex = 0;
        Transform _focusCurrentTarget = null;

        // 相机旋转角度
        float _cameraYawAngle = 0.0f;

        // 平滑转换的缓存
        Vector3 _currentFocusPosition = Vector3.zero;

        #endregion


        private bool GetFocusTarget()
        {
            if (focusTargetList.Count > 0)
            {
                _focusCurrentIndex = Math.Max(_focusCurrentIndex, 0);
                _focusCurrentIndex = Math.Min(_focusCurrentIndex, focusTargetList.Count - 1);

                if (focusTargetList[_focusCurrentIndex] == null)
                {
                    Debug.LogError("Target in Focus Target List is Missing!");
                    return false;
                }

                _focusCurrentTarget = focusTargetList[_focusCurrentIndex];
                _currentFocusPosition = _focusCurrentTarget.position;
                return true;
            }
            else
            {
                Debug.LogError("Focus Targets is not set");
                return false;
            }
        }

        private void ChangeToNextCameraTarget(InputAction.CallbackContext context)
        {
            do
            {
                _focusCurrentIndex = (_focusCurrentIndex + 1) % focusTargetList.Count;

            } while (!GetFocusTarget());
        }

        private void ChangeToPreviousCameraTarget(InputAction.CallbackContext context)
        {
            do
            {
                _focusCurrentIndex = (_focusCurrentIndex - 1 + focusTargetList.Count) % focusTargetList.Count;
            } while (!GetFocusTarget());
        }

        public void Start()
        {
            _gameStateManager = SeagullSama.Instance.GetManager<IGameStateManager>();

            _inputActions = SeagullSama.Instance.GetUtility<IInputUtility>().GetInputActions();
            _inputActions.CameraActions.ChangeToNextCameraAction.performed += ChangeToNextCameraTarget;
            _inputActions.CameraActions.ChangeToPreviousCameraAction.performed += ChangeToPreviousCameraTarget;

            _cameraRotateYaw = _inputActions.CameraActions.RotateCameraYaw;
            _cameraRotatePitch = _inputActions.CameraActions.RotateCameraPitch;
            _cameraZoomInput = _inputActions.CameraActions.ZoomCameraView;

            GetFocusTarget();
        }

        public void OnDestroy()
        {
            _inputActions.CameraActions.ChangeToNextCameraAction.performed -= ChangeToNextCameraTarget;
            _inputActions.CameraActions.ChangeToPreviousCameraAction.performed -= ChangeToPreviousCameraTarget;
        }

        public void Update()
        {
            switch (_gameStateManager.GameControlState)
            {
                case EGameControlState.TopViewMovement:
                    RotateCameraView();
                    ZoomCameraView();
                    UpdateTopViewMovement();
                    break;
                case EGameControlState.CameraRoaming:
                    Debug.Log("Camera Roaming");
                    break;
                default:
                    Debug.LogError("Unknown GameControlState: " + _gameStateManager.GameControlState);
                    break;
            }
        }

        private void RotateCameraView()
        {
            float rotateYaw = _cameraRotateYaw.ReadValue<float>();
            _cameraYawAngle += (rotateYaw * cameraRotateSpeed * Time.deltaTime + 360) % 360;

            float rotatePitch = _cameraRotatePitch.ReadValue<float>();
            cameraPitchAngle += rotatePitch * cameraRotateSpeed * Time.deltaTime;
            cameraPitchAngle = Mathf.Clamp(cameraPitchAngle, cameraMinPitchAngle, cameraMaxPitchAngle);
        }

        private void ZoomCameraView()
        {
            float zoomSpeed = _cameraZoomInput.ReadValue<float>();
            cameraDistance += zoomSpeed * Time.deltaTime;
            cameraDistance = Mathf.Clamp(cameraDistance, cameraMinDistance, cameraMaxDistance);
        }

        void UpdateTopViewMovement()
        {

            if (_focusCurrentTarget == null)
            {
                if (!GetFocusTarget())
                {
                    return;
                }
            }

            // 平滑锁定到 focusTarget 的位置, 速度为 cameraMoveSpeed
            _currentFocusPosition =
                Vector3.Lerp(_currentFocusPosition, _focusCurrentTarget.position, Time.deltaTime * cameraMoveSpeed);

            // 相机悬臂在 x-z 平面上的投影长度
            float cameraHeight = cameraDistance * Mathf.Sin(cameraPitchAngle * Mathf.Deg2Rad);
            float cameraLeverArm = cameraDistance * Mathf.Cos(cameraPitchAngle * Mathf.Deg2Rad);
            float cameraLeverArmX = cameraLeverArm * Mathf.Sin(_cameraYawAngle * Mathf.Deg2Rad);
            float cameraLeverArmZ = cameraLeverArm * Mathf.Cos(_cameraYawAngle * Mathf.Deg2Rad);

            transform.rotation = Quaternion.Euler(cameraPitchAngle, _cameraYawAngle, 0);

            transform.position = new Vector3(
                _currentFocusPosition.x - cameraLeverArmX,
                _currentFocusPosition.y + cameraHeight,
                _currentFocusPosition.z - cameraLeverArmZ
            );
        }
    }
}