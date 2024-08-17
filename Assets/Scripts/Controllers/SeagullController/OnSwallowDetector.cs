using System;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class OnSwallowDetector : MonoBehaviour
    {
        public Action<GameObject> OnSwallow = delegate { };

        private void OnTriggerEnter(Collider other)
        {
            GameObject otherGameObject = other.gameObject;
            while (otherGameObject.transform.parent != null)
            {
                otherGameObject = otherGameObject.transform.parent.gameObject;
            }

            OnSwallow?.Invoke(otherGameObject);
        }
    }
}