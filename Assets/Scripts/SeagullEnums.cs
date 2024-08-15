using System;
using System.Collections.Generic;
using SeagullSama.Controller;
using SeagullSama.Manager;
using UnityEngine;

namespace SeagullSama
{
    public enum EPickableItemType
    {
        GeneralItem,
        AbilityStone,
        // 奖励分数等
    }
    
    public static class AbilityHelper
    {
        public readonly static List<IAbility> AbilityList = new List<IAbility>
        {
            new TestAbility(),
            new SuperJumpAbility(),
            new DoubleJumpAbility(),
        };
    }

    public enum EAbilityType
    {
        TestAbility,
        SuperJumpAbility,
        DoubleJumpAbility
    }
}