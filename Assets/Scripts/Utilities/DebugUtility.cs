using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using UnityEngine;

namespace SeagullSama.Utility
{
    public interface IDebugUtility : IUtility
    {
        public Material GetGizmosMaterial(int index);
    }

    public class DebugUtility : IDebugUtility
    {
        private Material[] gizmosMaterials;

        public void Init()
        {
            Debug.Log("DebugUtility Init");

            // 读取 Assets/Resources/Materials/GizmosMaterials 文件夹下的所有材质
            gizmosMaterials = Resources.LoadAll<Material>("Materials/GizmosMaterials");

            if (gizmosMaterials.Length == 0)
            {
                Debug.LogError("GizmosMaterials is empty");
            }
        }

        public Material GetGizmosMaterial(int index)
        {
            index = index % gizmosMaterials.Length;
            return gizmosMaterials[index];
        }
    }
}