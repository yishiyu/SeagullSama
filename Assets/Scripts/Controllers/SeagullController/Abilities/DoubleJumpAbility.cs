using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using SeagullSama.Utility;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class DoubleJumpAbility : SeagullAbility
    {
        private IDebugUtility _debugUtility;

        override public void Activate()
        {
            SeagullController seagullController = SeagullController.Instance;
            seagullController.maxJumpCount = 2;

            if (_debugUtility == null)
            {
                _debugUtility = SeagullSama.Instance.GetUtility<IDebugUtility>();
            }

            Debug.Log("SeagullSama can jump twice now!");
            _debugUtility.PrintToScreen("SeagullSama can jump twice now!");
            SeagullSama.Instance.GetManager<IAbilityManager>().UnEquipAbilityByName(AbilityName);
        }

        override public void Deactivate()
        {
            Debug.Log("DoubleJumpAbility Deactivate");
        }
    }
}