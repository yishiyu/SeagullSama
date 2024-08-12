using System;
using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using SeagullSama.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace SeagullSama.Controller
{
    public class PausePanelController : MonoBehaviour
    {
        public Button quitButton;

        private void Start()
        {
            quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private void OnQuitButtonClicked()
        {
            // 退出游戏
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}