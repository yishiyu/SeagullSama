using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class DoubleJumpAbility : SeagullAbility
    {
        override public void Activate()
        {
            SeagullController seagullController = SeagullController.Instance;
            seagullController.maxJumpCount = 2;
            Debug.Log("DoubleJumpAbility Activate");
            Debug.Log("SeagullSama can jump twice now!");
            SeagullSama.Instance.GetManager<IAbilityManager>().UnEquipAbilityByName(AbilityName);
        }

        override public void Deactivate()
        {
            Debug.Log("DoubleJumpAbility Deactivate");
        }
    }
}