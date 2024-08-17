using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using SeagullSama.Utility;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class TestAbility : SeagullAbility
    {
        private IDebugUtility _debugUtility;
        private GameObject _prefab;

        override public void Activate()
        {
            // 使用 AB 包加载资源
            _prefab = SeagullSama.Instance.GetUtility<IAssetUtility>()
                .LoadAsset<GameObject>("prefabs.assetbundle", "PickableCube");
            // _prefab = Resources.Load<GameObject>("GeneralPickableItem");

            // 发射一个物体
            GameObject cube = GameObject.Instantiate(
                _prefab, SeagullController.Instance.transform.position + Vector3.up, Quaternion.identity);
            cube.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);

            if (_debugUtility == null)
            {
                _debugUtility = SeagullSama.Instance.GetUtility<IDebugUtility>();
            }

            Debug.Log("TestAbility Activate");
            _debugUtility.PrintToScreen("TestAbility Activate");
        }

        override public void Deactivate()
        {
            Debug.Log("TestAbility Deactivate");
        }
    }
}