using System;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class OnLandDetector : MonoBehaviour
    {
        public Action OnLand = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            OnLand?.Invoke();
        }
    }
}