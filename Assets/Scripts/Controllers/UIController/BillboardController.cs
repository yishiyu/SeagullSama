using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SeagullSama.Controller
{
    public class BillboardController : MonoBehaviour
    {
        public enum EBillboardType
        {
            LookAtCamera,
            CameraForward
        }

        public EBillboardType billboardType = EBillboardType.LookAtCamera;
        public bool lockX = false;
        public bool lockY = false;
        public bool lockZ = false;

        private Vector3 _originalRotation;

        private void Awake()
        {
            _originalRotation = transform.rotation.eulerAngles;
        }

        private void LateUpdate()
        {
            switch (billboardType)
            {
                case EBillboardType.LookAtCamera:
                    transform.LookAt(Camera.main.transform.position, Vector3.up);
                    break;
                case EBillboardType.CameraForward:
                    transform.forward = Camera.main.transform.forward;
                    break;
                default:
                    break;
            }

            Vector3 rotation = transform.rotation.eulerAngles;
            rotation = new Vector3(
                lockX ? _originalRotation.x : rotation.x,
                lockY ? _originalRotation.y : rotation.y,
                lockZ ? _originalRotation.z : rotation.z
            );
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}