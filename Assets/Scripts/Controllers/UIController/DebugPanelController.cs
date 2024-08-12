using System;
using System.Collections;
using System.Collections.Generic;
using SeagullSama.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SeagullSama.Controller
{
    public class DebugPanelController : MonoBehaviour
    {
        public TextMeshProUGUI debugText;

        public void Start()
        {
            SeagullSama.Instance.GetUtility<IDebugUtility>().OnPrintToScreen += SetDebugText;
        }

        private void SetDebugText(string message)
        {
            debugText.text = message;
        }
    }
}