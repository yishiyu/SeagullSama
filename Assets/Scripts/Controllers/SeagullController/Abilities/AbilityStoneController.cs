using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SeagullSama.Controller
{
    public class AbilityStoneController : PickableItemController
    {
        [Header("Configuration"), Tooltip("技能类型")]
        public EAbilityType abilityType;

        public TextMeshProUGUI abilityNameText;

        // 在编辑器中隐藏
        [HideInInspector]
        public EPickableItemType PickableItemType => EPickableItemType.AbilityStone;

        public void Start()
        {
            if (abilityNameText)
            {
                abilityNameText.text = abilityType.ToString() + "\n" + abilityNameText.text;
            }
        }

        override public object GetItem()
        {
            return abilityType.ToString();
        }
    }
}