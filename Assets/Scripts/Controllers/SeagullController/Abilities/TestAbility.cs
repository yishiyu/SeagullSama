using System.Collections;
using System.Collections.Generic;
using SeagullSama.Manager;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class TestAbility : SeagullAbility
    {
        override public void Activate()
        {
            Debug.Log("TestAbility Activate");
        }

        override public void Deactivate()
        {
            Debug.Log("TestAbility Deactivate");
        }
    }
}