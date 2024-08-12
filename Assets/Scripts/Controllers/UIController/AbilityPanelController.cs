using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using SeagullSama.Manager;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class AbilityPanelController : MonoBehaviour
    {
        public Transform abilityDetailContainer;
        public AbilityDetailController abilityDetailPrefab;

        private void Start()
        {
            EventBus.AddListener<EquippedAbilitiesChangedEvent>(OnEquippedAbilitiesChanged);
        }

        private void OnEquippedAbilitiesChanged(EquippedAbilitiesChangedEvent evt)
        {
            // 清空所有技能详情
            for(int i = 0; i < abilityDetailContainer.childCount; i++)
            {
                Destroy(abilityDetailContainer.GetChild(i).gameObject);
            }

            List<string> equippedAbilities =
                SeagullSama.Instance.GetManager<IAbilityManager>().GetEquippedAbilityNameList();

            foreach (var abilityName in equippedAbilities)
            {
                // 创建技能详情 AbilityDetailController
                AbilityDetailController abilityDetail =
                    Instantiate(abilityDetailPrefab, abilityDetailContainer.transform);
                abilityDetail.SetAbilityName(abilityName);
            }

        }
    }
}