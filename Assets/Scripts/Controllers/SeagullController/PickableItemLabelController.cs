using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SeagullSama.Controller
{
    [RequireComponent(typeof(PickableItemController))]
    public class PickableItemLabelController : MonoBehaviour
    {
        public TextMeshProUGUI abilityNameText;

        private void Start()
        {
            PickableItemController pickableItem = GetComponent<PickableItemController>();
            string text = abilityNameText.text + "\nItemMass:\t" + pickableItem.itemMass +
                          "\nItemSwallowLevel:\t" + pickableItem.itemSwallowLevel +
                          "\nSwallowForcePower:\t" + pickableItem.itemSwallowForcePower +
                          "\nSwallowRadiusPower:\t" + pickableItem.itemSwallowRadiusPower +
                          "\nSwallowDepthPower:\t" + pickableItem.itemSwallowDepthPower +
                          "\nSwallowLevelPower:\t" + pickableItem.itemSwallowLevelPower;
            abilityNameText.text = text;
        }
    }
}