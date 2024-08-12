using System.Collections;
using System.Collections.Generic;
using SeagullSama.Utility;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class MainUIController : MonoBehaviour
    {
        public AbilityPanelController abilityPanelController;
        public PausePanelController pausePanelController;

        private void Start()
        {
            abilityPanelController.gameObject.SetActive(true);
            pausePanelController.gameObject.SetActive(false);

            SeagullSama.Instance.GetUtility<IInputUtility>().GetInputActions().GameModeActions.PauseGameAction
                .performed += ctx =>
            {
                if (pausePanelController.gameObject.activeSelf)
                {
                    pausePanelController.gameObject.SetActive(false);
                }
                else
                {
                    pausePanelController.gameObject.SetActive(true);
                }
            };
        }
    }
}