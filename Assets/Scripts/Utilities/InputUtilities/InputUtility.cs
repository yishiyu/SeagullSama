using UnityEngine;
using SeagullSama.Core;

namespace SeagullSama.Utility
{
    public interface IInputUtility : IUtility
    {
        public SeagullInput GetInputActions();
    }


    public class InputManager : IInputUtility
    {
        private SeagullInput _inputActions;

        public void Init()
        {
            Debug.Log("InputUtility Init");
            _inputActions = new SeagullInput();

            _inputActions.Enable();
        }

        public SeagullInput GetInputActions()
        {
            return _inputActions;
        }
    }
}