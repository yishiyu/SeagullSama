using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class TestAbility : SeagullAbility
    {
        override public void Activate()
        {
            // 发射一个物体
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = SeagullController.Instance.transform.position + new Vector3(0, 1, 0);
            cube.AddComponent<PickableItemController>();
            cube.AddComponent<Rigidbody>();
            cube.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);

            Debug.Log("TestAbility Activate");
        }

        override public void Deactivate()
        {
            Debug.Log("TestAbility Deactivate");
        }
    }
}