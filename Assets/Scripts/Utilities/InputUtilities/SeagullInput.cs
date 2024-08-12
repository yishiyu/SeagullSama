//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/Input/SeagullInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace SeagullSama.Utility
{
    public partial class @SeagullInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @SeagullInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""SeagullInput"",
    ""maps"": [
        {
            ""name"": ""CharacterActions"",
            ""id"": ""a46d26d0-f122-4ada-8edc-db9f8fc987f3"",
            ""actions"": [
                {
                    ""name"": ""MovementInput"",
                    ""type"": ""Value"",
                    ""id"": ""c4f4cc93-1c41-4181-b355-35ccf3a49f17"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseLocation"",
                    ""type"": ""Value"",
                    ""id"": ""802fa275-f34f-462a-944a-5a035abdc85a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""JumpAction"",
                    ""type"": ""Button"",
                    ""id"": ""6276016b-cc65-4e71-b3b2-d00a88acab77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwallowAction"",
                    ""type"": ""Button"",
                    ""id"": ""ab4842fd-5ee3-4a96-b7c9-fc1bc63569dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""77fb21ec-cac8-46a7-9ef9-ee64d16e8a76"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d8efa595-f432-4933-8251-c80ef18f0479"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7762740a-9afa-434e-9abc-a0a1dbd168fc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e8c3622-722f-4aee-bac3-7a3e265c684f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""166a1803-d9c1-42c6-97b6-8ef5ee833c67"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9ef9fac6-3b01-42e2-866d-ba919d9230c1"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLocation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f17b7220-a3a6-4b6f-9699-36336dc12cca"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87203ea7-76ef-4b87-8c3f-57405a48eed2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwallowAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CameraActions"",
            ""id"": ""44ac28cf-aff0-407c-87c3-03824f470252"",
            ""actions"": [
                {
                    ""name"": ""ChangeToNextCameraAction"",
                    ""type"": ""Button"",
                    ""id"": ""4eca24e6-bbb5-42e3-9666-acf6e23d02a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeToPreviousCameraAction1"",
                    ""type"": ""Button"",
                    ""id"": ""3cf9cff5-77ce-4310-bb45-99b6fb1bccc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateCameraView"",
                    ""type"": ""Value"",
                    ""id"": ""0606bbde-c50b-4de9-9714-4424f63b24d2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e366ff99-e0dd-4558-9829-db0829027f6c"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToNextCameraAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dfe911a-42b6-42c8-ada3-2b48606a152f"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToPreviousCameraAction1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ae042118-83ac-412e-8e52-c38d29a00c5b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraView"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9b6f981b-9fcb-40b8-b616-03056d5a4008"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""39cf7b53-ca52-48f8-a105-33528e46163a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCameraView"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameModeActions"",
            ""id"": ""cbcaae17-6402-475e-a0d5-6ebb862e26bd"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""AbilityActions"",
            ""id"": ""0f8ecf59-3600-42c8-a3f2-b40bf6f3f0a4"",
            ""actions"": [
                {
                    ""name"": ""ActiveAbilityAction1"",
                    ""type"": ""Button"",
                    ""id"": ""5335b72d-10c4-4010-a5f0-ceba1fff353a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActiveAbilityAction2"",
                    ""type"": ""Button"",
                    ""id"": ""61d48f2c-4bf9-412e-8730-a05b2e8e14eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActiveAbilityAction3"",
                    ""type"": ""Button"",
                    ""id"": ""4f5f8794-29fd-4192-8d3a-531bf675fc65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActiveAbilityAction4"",
                    ""type"": ""Button"",
                    ""id"": ""79a0b840-0e68-436a-9c56-24ad9f1b6d87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActiveAbilityAction5"",
                    ""type"": ""Button"",
                    ""id"": ""88c07224-d7d4-455f-af68-c381173e1154"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActiveAbilityAction6"",
                    ""type"": ""Button"",
                    ""id"": ""dfdcdf81-6f31-4d5d-931c-26dc40946071"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cda5f8fb-7540-455e-9e0e-0e89e1b3851b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveAbilityAction1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7ceed4b-480e-4b7c-a936-e69c4282a292"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveAbilityAction2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6334cec-203f-44ac-9e5d-9d37bd3f56ac"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveAbilityAction3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ee57a54-5822-4cca-9623-7bf298ccbc50"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveAbilityAction4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""832d4f8f-d4e4-41b6-aa31-a574b46ee4ce"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveAbilityAction5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e78a102-f055-4076-9b8f-71f5e01eb490"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActiveAbilityAction6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // CharacterActions
            m_CharacterActions = asset.FindActionMap("CharacterActions", throwIfNotFound: true);
            m_CharacterActions_MovementInput = m_CharacterActions.FindAction("MovementInput", throwIfNotFound: true);
            m_CharacterActions_MouseLocation = m_CharacterActions.FindAction("MouseLocation", throwIfNotFound: true);
            m_CharacterActions_JumpAction = m_CharacterActions.FindAction("JumpAction", throwIfNotFound: true);
            m_CharacterActions_SwallowAction = m_CharacterActions.FindAction("SwallowAction", throwIfNotFound: true);
            // CameraActions
            m_CameraActions = asset.FindActionMap("CameraActions", throwIfNotFound: true);
            m_CameraActions_ChangeToNextCameraAction = m_CameraActions.FindAction("ChangeToNextCameraAction", throwIfNotFound: true);
            m_CameraActions_ChangeToPreviousCameraAction1 = m_CameraActions.FindAction("ChangeToPreviousCameraAction1", throwIfNotFound: true);
            m_CameraActions_RotateCameraView = m_CameraActions.FindAction("RotateCameraView", throwIfNotFound: true);
            // GameModeActions
            m_GameModeActions = asset.FindActionMap("GameModeActions", throwIfNotFound: true);
            // AbilityActions
            m_AbilityActions = asset.FindActionMap("AbilityActions", throwIfNotFound: true);
            m_AbilityActions_ActiveAbilityAction1 = m_AbilityActions.FindAction("ActiveAbilityAction1", throwIfNotFound: true);
            m_AbilityActions_ActiveAbilityAction2 = m_AbilityActions.FindAction("ActiveAbilityAction2", throwIfNotFound: true);
            m_AbilityActions_ActiveAbilityAction3 = m_AbilityActions.FindAction("ActiveAbilityAction3", throwIfNotFound: true);
            m_AbilityActions_ActiveAbilityAction4 = m_AbilityActions.FindAction("ActiveAbilityAction4", throwIfNotFound: true);
            m_AbilityActions_ActiveAbilityAction5 = m_AbilityActions.FindAction("ActiveAbilityAction5", throwIfNotFound: true);
            m_AbilityActions_ActiveAbilityAction6 = m_AbilityActions.FindAction("ActiveAbilityAction6", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // CharacterActions
        private readonly InputActionMap m_CharacterActions;
        private List<ICharacterActionsActions> m_CharacterActionsActionsCallbackInterfaces = new List<ICharacterActionsActions>();
        private readonly InputAction m_CharacterActions_MovementInput;
        private readonly InputAction m_CharacterActions_MouseLocation;
        private readonly InputAction m_CharacterActions_JumpAction;
        private readonly InputAction m_CharacterActions_SwallowAction;
        public struct CharacterActionsActions
        {
            private @SeagullInput m_Wrapper;
            public CharacterActionsActions(@SeagullInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MovementInput => m_Wrapper.m_CharacterActions_MovementInput;
            public InputAction @MouseLocation => m_Wrapper.m_CharacterActions_MouseLocation;
            public InputAction @JumpAction => m_Wrapper.m_CharacterActions_JumpAction;
            public InputAction @SwallowAction => m_Wrapper.m_CharacterActions_SwallowAction;
            public InputActionMap Get() { return m_Wrapper.m_CharacterActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActionsActions set) { return set.Get(); }
            public void AddCallbacks(ICharacterActionsActions instance)
            {
                if (instance == null || m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Add(instance);
                @MovementInput.started += instance.OnMovementInput;
                @MovementInput.performed += instance.OnMovementInput;
                @MovementInput.canceled += instance.OnMovementInput;
                @MouseLocation.started += instance.OnMouseLocation;
                @MouseLocation.performed += instance.OnMouseLocation;
                @MouseLocation.canceled += instance.OnMouseLocation;
                @JumpAction.started += instance.OnJumpAction;
                @JumpAction.performed += instance.OnJumpAction;
                @JumpAction.canceled += instance.OnJumpAction;
                @SwallowAction.started += instance.OnSwallowAction;
                @SwallowAction.performed += instance.OnSwallowAction;
                @SwallowAction.canceled += instance.OnSwallowAction;
            }

            private void UnregisterCallbacks(ICharacterActionsActions instance)
            {
                @MovementInput.started -= instance.OnMovementInput;
                @MovementInput.performed -= instance.OnMovementInput;
                @MovementInput.canceled -= instance.OnMovementInput;
                @MouseLocation.started -= instance.OnMouseLocation;
                @MouseLocation.performed -= instance.OnMouseLocation;
                @MouseLocation.canceled -= instance.OnMouseLocation;
                @JumpAction.started -= instance.OnJumpAction;
                @JumpAction.performed -= instance.OnJumpAction;
                @JumpAction.canceled -= instance.OnJumpAction;
                @SwallowAction.started -= instance.OnSwallowAction;
                @SwallowAction.performed -= instance.OnSwallowAction;
                @SwallowAction.canceled -= instance.OnSwallowAction;
            }

            public void RemoveCallbacks(ICharacterActionsActions instance)
            {
                if (m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICharacterActionsActions instance)
            {
                foreach (var item in m_Wrapper.m_CharacterActionsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CharacterActionsActions @CharacterActions => new CharacterActionsActions(this);

        // CameraActions
        private readonly InputActionMap m_CameraActions;
        private List<ICameraActionsActions> m_CameraActionsActionsCallbackInterfaces = new List<ICameraActionsActions>();
        private readonly InputAction m_CameraActions_ChangeToNextCameraAction;
        private readonly InputAction m_CameraActions_ChangeToPreviousCameraAction1;
        private readonly InputAction m_CameraActions_RotateCameraView;
        public struct CameraActionsActions
        {
            private @SeagullInput m_Wrapper;
            public CameraActionsActions(@SeagullInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @ChangeToNextCameraAction => m_Wrapper.m_CameraActions_ChangeToNextCameraAction;
            public InputAction @ChangeToPreviousCameraAction1 => m_Wrapper.m_CameraActions_ChangeToPreviousCameraAction1;
            public InputAction @RotateCameraView => m_Wrapper.m_CameraActions_RotateCameraView;
            public InputActionMap Get() { return m_Wrapper.m_CameraActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraActionsActions set) { return set.Get(); }
            public void AddCallbacks(ICameraActionsActions instance)
            {
                if (instance == null || m_Wrapper.m_CameraActionsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_CameraActionsActionsCallbackInterfaces.Add(instance);
                @ChangeToNextCameraAction.started += instance.OnChangeToNextCameraAction;
                @ChangeToNextCameraAction.performed += instance.OnChangeToNextCameraAction;
                @ChangeToNextCameraAction.canceled += instance.OnChangeToNextCameraAction;
                @ChangeToPreviousCameraAction1.started += instance.OnChangeToPreviousCameraAction1;
                @ChangeToPreviousCameraAction1.performed += instance.OnChangeToPreviousCameraAction1;
                @ChangeToPreviousCameraAction1.canceled += instance.OnChangeToPreviousCameraAction1;
                @RotateCameraView.started += instance.OnRotateCameraView;
                @RotateCameraView.performed += instance.OnRotateCameraView;
                @RotateCameraView.canceled += instance.OnRotateCameraView;
            }

            private void UnregisterCallbacks(ICameraActionsActions instance)
            {
                @ChangeToNextCameraAction.started -= instance.OnChangeToNextCameraAction;
                @ChangeToNextCameraAction.performed -= instance.OnChangeToNextCameraAction;
                @ChangeToNextCameraAction.canceled -= instance.OnChangeToNextCameraAction;
                @ChangeToPreviousCameraAction1.started -= instance.OnChangeToPreviousCameraAction1;
                @ChangeToPreviousCameraAction1.performed -= instance.OnChangeToPreviousCameraAction1;
                @ChangeToPreviousCameraAction1.canceled -= instance.OnChangeToPreviousCameraAction1;
                @RotateCameraView.started -= instance.OnRotateCameraView;
                @RotateCameraView.performed -= instance.OnRotateCameraView;
                @RotateCameraView.canceled -= instance.OnRotateCameraView;
            }

            public void RemoveCallbacks(ICameraActionsActions instance)
            {
                if (m_Wrapper.m_CameraActionsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ICameraActionsActions instance)
            {
                foreach (var item in m_Wrapper.m_CameraActionsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_CameraActionsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public CameraActionsActions @CameraActions => new CameraActionsActions(this);

        // GameModeActions
        private readonly InputActionMap m_GameModeActions;
        private List<IGameModeActionsActions> m_GameModeActionsActionsCallbackInterfaces = new List<IGameModeActionsActions>();
        public struct GameModeActionsActions
        {
            private @SeagullInput m_Wrapper;
            public GameModeActionsActions(@SeagullInput wrapper) { m_Wrapper = wrapper; }
            public InputActionMap Get() { return m_Wrapper.m_GameModeActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameModeActionsActions set) { return set.Get(); }
            public void AddCallbacks(IGameModeActionsActions instance)
            {
                if (instance == null || m_Wrapper.m_GameModeActionsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GameModeActionsActionsCallbackInterfaces.Add(instance);
            }

            private void UnregisterCallbacks(IGameModeActionsActions instance)
            {
            }

            public void RemoveCallbacks(IGameModeActionsActions instance)
            {
                if (m_Wrapper.m_GameModeActionsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGameModeActionsActions instance)
            {
                foreach (var item in m_Wrapper.m_GameModeActionsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GameModeActionsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GameModeActionsActions @GameModeActions => new GameModeActionsActions(this);

        // AbilityActions
        private readonly InputActionMap m_AbilityActions;
        private List<IAbilityActionsActions> m_AbilityActionsActionsCallbackInterfaces = new List<IAbilityActionsActions>();
        private readonly InputAction m_AbilityActions_ActiveAbilityAction1;
        private readonly InputAction m_AbilityActions_ActiveAbilityAction2;
        private readonly InputAction m_AbilityActions_ActiveAbilityAction3;
        private readonly InputAction m_AbilityActions_ActiveAbilityAction4;
        private readonly InputAction m_AbilityActions_ActiveAbilityAction5;
        private readonly InputAction m_AbilityActions_ActiveAbilityAction6;
        public struct AbilityActionsActions
        {
            private @SeagullInput m_Wrapper;
            public AbilityActionsActions(@SeagullInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @ActiveAbilityAction1 => m_Wrapper.m_AbilityActions_ActiveAbilityAction1;
            public InputAction @ActiveAbilityAction2 => m_Wrapper.m_AbilityActions_ActiveAbilityAction2;
            public InputAction @ActiveAbilityAction3 => m_Wrapper.m_AbilityActions_ActiveAbilityAction3;
            public InputAction @ActiveAbilityAction4 => m_Wrapper.m_AbilityActions_ActiveAbilityAction4;
            public InputAction @ActiveAbilityAction5 => m_Wrapper.m_AbilityActions_ActiveAbilityAction5;
            public InputAction @ActiveAbilityAction6 => m_Wrapper.m_AbilityActions_ActiveAbilityAction6;
            public InputActionMap Get() { return m_Wrapper.m_AbilityActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AbilityActionsActions set) { return set.Get(); }
            public void AddCallbacks(IAbilityActionsActions instance)
            {
                if (instance == null || m_Wrapper.m_AbilityActionsActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_AbilityActionsActionsCallbackInterfaces.Add(instance);
                @ActiveAbilityAction1.started += instance.OnActiveAbilityAction1;
                @ActiveAbilityAction1.performed += instance.OnActiveAbilityAction1;
                @ActiveAbilityAction1.canceled += instance.OnActiveAbilityAction1;
                @ActiveAbilityAction2.started += instance.OnActiveAbilityAction2;
                @ActiveAbilityAction2.performed += instance.OnActiveAbilityAction2;
                @ActiveAbilityAction2.canceled += instance.OnActiveAbilityAction2;
                @ActiveAbilityAction3.started += instance.OnActiveAbilityAction3;
                @ActiveAbilityAction3.performed += instance.OnActiveAbilityAction3;
                @ActiveAbilityAction3.canceled += instance.OnActiveAbilityAction3;
                @ActiveAbilityAction4.started += instance.OnActiveAbilityAction4;
                @ActiveAbilityAction4.performed += instance.OnActiveAbilityAction4;
                @ActiveAbilityAction4.canceled += instance.OnActiveAbilityAction4;
                @ActiveAbilityAction5.started += instance.OnActiveAbilityAction5;
                @ActiveAbilityAction5.performed += instance.OnActiveAbilityAction5;
                @ActiveAbilityAction5.canceled += instance.OnActiveAbilityAction5;
                @ActiveAbilityAction6.started += instance.OnActiveAbilityAction6;
                @ActiveAbilityAction6.performed += instance.OnActiveAbilityAction6;
                @ActiveAbilityAction6.canceled += instance.OnActiveAbilityAction6;
            }

            private void UnregisterCallbacks(IAbilityActionsActions instance)
            {
                @ActiveAbilityAction1.started -= instance.OnActiveAbilityAction1;
                @ActiveAbilityAction1.performed -= instance.OnActiveAbilityAction1;
                @ActiveAbilityAction1.canceled -= instance.OnActiveAbilityAction1;
                @ActiveAbilityAction2.started -= instance.OnActiveAbilityAction2;
                @ActiveAbilityAction2.performed -= instance.OnActiveAbilityAction2;
                @ActiveAbilityAction2.canceled -= instance.OnActiveAbilityAction2;
                @ActiveAbilityAction3.started -= instance.OnActiveAbilityAction3;
                @ActiveAbilityAction3.performed -= instance.OnActiveAbilityAction3;
                @ActiveAbilityAction3.canceled -= instance.OnActiveAbilityAction3;
                @ActiveAbilityAction4.started -= instance.OnActiveAbilityAction4;
                @ActiveAbilityAction4.performed -= instance.OnActiveAbilityAction4;
                @ActiveAbilityAction4.canceled -= instance.OnActiveAbilityAction4;
                @ActiveAbilityAction5.started -= instance.OnActiveAbilityAction5;
                @ActiveAbilityAction5.performed -= instance.OnActiveAbilityAction5;
                @ActiveAbilityAction5.canceled -= instance.OnActiveAbilityAction5;
                @ActiveAbilityAction6.started -= instance.OnActiveAbilityAction6;
                @ActiveAbilityAction6.performed -= instance.OnActiveAbilityAction6;
                @ActiveAbilityAction6.canceled -= instance.OnActiveAbilityAction6;
            }

            public void RemoveCallbacks(IAbilityActionsActions instance)
            {
                if (m_Wrapper.m_AbilityActionsActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IAbilityActionsActions instance)
            {
                foreach (var item in m_Wrapper.m_AbilityActionsActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_AbilityActionsActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public AbilityActionsActions @AbilityActions => new AbilityActionsActions(this);
        public interface ICharacterActionsActions
        {
            void OnMovementInput(InputAction.CallbackContext context);
            void OnMouseLocation(InputAction.CallbackContext context);
            void OnJumpAction(InputAction.CallbackContext context);
            void OnSwallowAction(InputAction.CallbackContext context);
        }
        public interface ICameraActionsActions
        {
            void OnChangeToNextCameraAction(InputAction.CallbackContext context);
            void OnChangeToPreviousCameraAction1(InputAction.CallbackContext context);
            void OnRotateCameraView(InputAction.CallbackContext context);
        }
        public interface IGameModeActionsActions
        {
        }
        public interface IAbilityActionsActions
        {
            void OnActiveAbilityAction1(InputAction.CallbackContext context);
            void OnActiveAbilityAction2(InputAction.CallbackContext context);
            void OnActiveAbilityAction3(InputAction.CallbackContext context);
            void OnActiveAbilityAction4(InputAction.CallbackContext context);
            void OnActiveAbilityAction5(InputAction.CallbackContext context);
            void OnActiveAbilityAction6(InputAction.CallbackContext context);
        }
    }
}
