using System;
using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using SeagullSama.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SeagullSama.Manager
{
    public interface IAbility
    {
        public string AbilityName { get; }

        public void Activate();

        public void Deactivate();

        public bool IsActive();

        // TODO: 是否被激活, 剩余冷却事件, 是否在 CD 中...
    }

    public interface IAbilityManager : IManager
    {
        public bool RegisterAbility(IAbility ability);

        public bool EquipAbility(string abilityName);

        public bool UnEquipAbilityByName(string abilityName);

        public bool IsAbilityEquipped(string abilityName);

        public bool ActivateAbilityByName(string abilityName);

        public bool DeactivateAbilityByName(string abilityName);

        public bool IsAbilityActive(string abilityName);

        public List<IAbility> GetAbilityList();

        public List<string> GetAbilityNameList();

        public List<IAbility> GetEquippedAbilityList();

        public List<string> GetEquippedAbilityNameList();
    }

    public class AbilityManager : IAbilityManager
    {
        private List<IAbility> equippedAbilities = new List<IAbility>();
        private Dictionary<string, IAbility> _abilityDict = new Dictionary<string, IAbility>();

        public void Init()
        {
            Debug.Log("AbilityManager Init");
            SeagullInput inputAction = SeagullSama.Instance.GetUtility<IInputUtility>().GetInputActions();
            inputAction.AbilityActions.ActiveAbilityAction1.performed += ctx => ActivateAbilityByIndex(0);
            inputAction.AbilityActions.ActiveAbilityAction2.performed += ctx => ActivateAbilityByIndex(1);
            inputAction.AbilityActions.ActiveAbilityAction3.performed += ctx => ActivateAbilityByIndex(2);
            inputAction.AbilityActions.ActiveAbilityAction4.performed += ctx => ActivateAbilityByIndex(3);
            inputAction.AbilityActions.ActiveAbilityAction5.performed += ctx => ActivateAbilityByIndex(4);
            inputAction.AbilityActions.ActiveAbilityAction6.performed += ctx => ActivateAbilityByIndex(5);
        }

        private bool ActivateAbilityByIndex(int index)
        {
            if (index < 0 || index >= equippedAbilities.Count)
            {
                return false;
            }

            return ActivateAbilityByName(equippedAbilities[index].AbilityName);
        }

        public bool RegisterAbility(IAbility ability)
        {
            if (_abilityDict.ContainsKey(ability.AbilityName))
            {
                Debug.LogError($"AbilityManager: Ability {ability.AbilityName} already exists.");
                return false;
            }

            _abilityDict.Add(ability.AbilityName, ability);
            return true;
        }

        public bool EquipAbility(string abilityName)
        {
            if (!_abilityDict.ContainsKey(abilityName))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} does not exist.");
                return false;
            }

            if (equippedAbilities.Contains(_abilityDict[abilityName]))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} is already equipped.");
                return false;
            }

            equippedAbilities.Add(_abilityDict[abilityName]);

            EventBus.Invoke(GameEvents.EquippedAbilitiesChangedEvent);
            return true;
        }

        public bool UnEquipAbilityByName(string abilityName)
        {
            if (!_abilityDict.ContainsKey(abilityName))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} does not exist.");
                return false;
            }

            if (!equippedAbilities.Contains(_abilityDict[abilityName]))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} is not equipped.");
                return false;
            }

            equippedAbilities.Remove(_abilityDict[abilityName]);
            EventBus.Invoke(GameEvents.EquippedAbilitiesChangedEvent);
            return true;
        }

        public bool IsAbilityEquipped(string abilityName)
        {
            if (!_abilityDict.ContainsKey(abilityName))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} does not exist.");
                return false;
            }

            return equippedAbilities.Contains(_abilityDict[abilityName]);
        }

        public bool ActivateAbilityByName(string abilityName)
        {
            if (!_abilityDict.ContainsKey(abilityName))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} does not exist.");
                return false;
            }

            if (!equippedAbilities.Contains(_abilityDict[abilityName]))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} is not equipped.");
                return false;
            }

            _abilityDict[abilityName].Activate();
            return true;
        }

        public bool DeactivateAbilityByName(string abilityName)
        {
            if (!_abilityDict.ContainsKey(abilityName))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} does not exist.");
                return false;
            }

            if (!equippedAbilities.Contains(_abilityDict[abilityName]))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} is not equipped.");
                return false;
            }

            _abilityDict[abilityName].Deactivate();
            return true;
        }

        public bool IsAbilityActive(string abilityName)
        {
            if (!_abilityDict.ContainsKey(abilityName))
            {
                Debug.LogError($"AbilityManager: Ability {abilityName} does not exist.");
                return false;
            }

            return _abilityDict[abilityName].IsActive();
        }

        public List<IAbility> GetAbilityList()
        {
            return new List<IAbility>(_abilityDict.Values);
        }

        public List<string> GetAbilityNameList()
        {
            return new List<string>(_abilityDict.Keys);
        }

        public List<IAbility> GetEquippedAbilityList()
        {
            return new List<IAbility>(equippedAbilities);
        }

        public List<string> GetEquippedAbilityNameList()
        {
            List<string> equippedAbilityNames = new List<string>();
            foreach (IAbility ability in equippedAbilities)
            {
                equippedAbilityNames.Add(ability.AbilityName);
            }

            return equippedAbilityNames;
        }
    }
}