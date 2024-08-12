using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeagullSama.Controller
{
    public class PickableItemController : MonoBehaviour, IPickableItem
    {
        public EPickableItemType PickableItemType => EPickableItemType.GeneralItem;

        public object GetItem()
        {
            return null;
        }
    }
}