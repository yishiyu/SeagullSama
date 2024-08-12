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
            Debug.Log("DoubleJumpAbility Activate");
        }

        override public void Deactivate()
        {
            Debug.Log("DoubleJumpAbility Deactivate");
        }
    }
}