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
    }

    public interface IPickableItem
    {
        public EPickableItemType PickableItemType { get; }

        // 获取 C# 装箱对象
        public object GetItem();
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