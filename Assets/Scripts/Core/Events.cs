using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeagullSama.Core
{
    public static class GameEvents
    {
        public static GameStateChangedEvent GameStateChangedEvent = new GameStateChangedEvent();
        public static EquippedAbilitiesChangedEvent EquippedAbilitiesChangedEvent = new EquippedAbilitiesChangedEvent();
    }


    public class GameStateChangedEvent : GameEvent
    {
    }

    public class EquippedAbilitiesChangedEvent : GameEvent
    {
    }
}