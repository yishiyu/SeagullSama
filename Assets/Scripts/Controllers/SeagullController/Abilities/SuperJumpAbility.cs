using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SeagullSama.Controller
{
    public class SuperJumpAbility : SeagullAbility
    {
        override public void Activate()
        {
            SeagullController seagullController = SeagullController.Instance;
            float originalJumpForce = seagullController.jumpForce;
            seagullController.jumpForce = 10f;
            seagullController.StartJumping(new InputAction.CallbackContext());
            seagullController.jumpForce = originalJumpForce;
            Debug.Log("SuperJumpAbility Activate");
            // SeagullSama.Instance.GetManager<IAbilityManager>().UnEquipAbilityByName(AbilityName);
        }

        override public void Deactivate()
        {
            Debug.Log("SuperJumpAbility Deactivate");
        }
    }
}