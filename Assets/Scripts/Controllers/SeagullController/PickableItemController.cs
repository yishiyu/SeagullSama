using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeagullSama.Controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickableItemController : MonoBehaviour
    {
        public EPickableItemType pickableItemType = EPickableItemType.GeneralItem;

        // 用于获取被检物体的专有属性,如技能石的技能
        public virtual object GetItem()
        {
            return null;
        }

        // 可被检物体的通用属性
        // 物体重量,可被吸收的等级
        public float itemMass = 1;
        public int itemSwallowLevel = 1;

        // 物体可以提供的成长属性
        public float itemSwallowForcePower = 2;
        public float itemSwallowRadiusPower = 1;
        public float itemSwallowDepthPower = 1;
        public float itemSwallowLevelPower = 0.4f;


        public void Awake()
        {
            GetComponent<Rigidbody>().mass = itemMass;
        }
    }
}