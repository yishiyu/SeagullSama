using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SeagullSama.Controller
{
    public class AbilityStoneController : MonoBehaviour, IPickableItem
    {
        [Header("Configuration"), Tooltip("技能类型")]
        public EAbilityType AbilityType;

        public TextMeshProUGUI abilityNameText;

        public EPickableItemType PickableItemType => EPickableItemType.AbilityStone;

        private void Start()
        {
            abilityNameText.text = AbilityType.ToString();
        }

        public object GetItem()
        {
            return AbilityType.ToString();
        }
    }
}