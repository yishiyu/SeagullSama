using System;
using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using UnityEngine;

namespace SeagullSama.Utility
{
    public interface IDebugUtility : IUtility
    {
        public Action<string> OnPrintToScreen { get; set; }

        public Material GetGizmosMaterial(int index);

        public void PrintToScreen(string message);
    }

    public class DebugUtility : IDebugUtility
    {
        private Material[] _gizmosMaterials;
        private Action<string> _onPrintToScreen;

        public Action<string> OnPrintToScreen
        {
            get => _onPrintToScreen;
            set => _onPrintToScreen = value;
        }

        public void Init()
        {
            Debug.Log("DebugUtility Init");

            // 读取 Assets/Resources/Materials/GizmosMaterials 文件夹下的所有材质
            _gizmosMaterials = Resources.LoadAll<Material>("Materials/GizmosMaterials");

            if (_gizmosMaterials.Length == 0)
            {
                Debug.LogError("GizmosMaterials is empty");
            }
        }

        public Material GetGizmosMaterial(int index)
        {
            index = index % _gizmosMaterials.Length;
            return _gizmosMaterials[index];
        }

        public void PrintToScreen(string message)
        {
            _onPrintToScreen?.Invoke(message);
        }
    }
}