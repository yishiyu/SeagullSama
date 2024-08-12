using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class AbilityDetailController : MonoBehaviour
    {
        public TextMeshProUGUI abilityNameText;

        public void SetAbilityName(string abilityName)
        {
            abilityNameText.text = abilityName;
        }
    }
}