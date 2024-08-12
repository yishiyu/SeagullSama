using System.Collections;
using System.Collections.Generic;
using SeagullSama.Core;
using UnityEngine;

namespace SeagullSama.Manager
{
    // public enum EGameState
    // {
    //     Play,
    //     Pause,
    //     GameOver
    // }

    public enum EGameControlState
    {
        TopViewMovement,
        CameraRoaming

        // FirstPerson,
        // ThirdPerson
    }

    public interface IGameStateManager : IManager
    {
        public EGameControlState GameControlState { get; }
    }


    public class GameStateManager : IGameStateManager
    {
        private EGameControlState _gameControlStateState = EGameControlState.TopViewMovement;

        EGameControlState IGameStateManager.GameControlState => _gameControlStateState;

        public void Init()
        {
            Debug.Log("GameStateManager Init");
        }
    }
}