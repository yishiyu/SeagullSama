using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using SeagullSama.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SeagullSama.Controller
{
    public class SuperJumpAbility : SeagullAbility
    {
        private IDebugUtility _debugUtility;

        override public void Activate()
        {
            SeagullController seagullController = SeagullController.Instance;
            float originalJumpForce = seagullController.jumpForce;
            seagullController.jumpForce = 10f;
            seagullController.StartJumping(new InputAction.CallbackContext());
            seagullController.jumpForce = originalJumpForce;

            if (_debugUtility == null)
            {
                _debugUtility = SeagullSama.Instance.GetUtility<IDebugUtility>();
            }

            Debug.Log("SuperJumpAbility Activate");
            _debugUtility.PrintToScreen("SuperJumpAbility Activate");
            // SeagullSama.Instance.GetManager<IAbilityManager>().UnEquipAbilityByName(AbilityName);
        }

        override public void Deactivate()
        {
            Debug.Log("SuperJumpAbility Deactivate");
        }
    }
}