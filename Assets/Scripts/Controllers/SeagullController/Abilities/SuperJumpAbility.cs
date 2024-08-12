using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class SuperJumpAbility : SeagullAbility
    {
        override public void Activate()
        {
            Debug.Log("SuperJumpAbility Activate");
        }

        override public void Deactivate()
        {
            Debug.Log("SuperJumpAbility Deactivate");
        }
    }
}