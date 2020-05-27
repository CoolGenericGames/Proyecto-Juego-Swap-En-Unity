// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/InputActionsGameplay.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActionsGameplay : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActionsGameplay()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActionsGameplay"",
    ""maps"": [
        {
            ""name"": ""Teclado"",
            ""id"": ""dfbb7882-d57e-4767-9d1d-4219dc6dcd0c"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""Value"",
                    ""id"": ""9792fb47-8c2e-4ba4-92b5-e1a3e84c401c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Disparar"",
                    ""type"": ""Button"",
                    ""id"": ""d1319e27-d000-4787-8c62-56eb7b182572"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CambiarColor"",
                    ""type"": ""Button"",
                    ""id"": ""7875ef23-07d8-4f9e-a323-a67c433114f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Teclado (WASD)"",
                    ""id"": ""f7022021-a431-4497-9a23-9961a8ecf466"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4a9168b-b2cc-4798-a224-383acf0de445"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""664691db-7593-4df4-9f24-a1e282eb95b3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7988de2a-106e-45b6-8129-445c0c4d90c5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""993a0af8-c8a5-49b6-a9dc-525ab07219ac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc2e329c-8d5c-4fb3-92b0-d2f67237fa05"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Disparar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""822617f3-52f8-49c6-82d5-fac5e1b90f6c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CambiarColor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Teclado
        m_Teclado = asset.FindActionMap("Teclado", throwIfNotFound: true);
        m_Teclado_Mover = m_Teclado.FindAction("Mover", throwIfNotFound: true);
        m_Teclado_Disparar = m_Teclado.FindAction("Disparar", throwIfNotFound: true);
        m_Teclado_CambiarColor = m_Teclado.FindAction("CambiarColor", throwIfNotFound: true);
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

    // Teclado
    private readonly InputActionMap m_Teclado;
    private ITecladoActions m_TecladoActionsCallbackInterface;
    private readonly InputAction m_Teclado_Mover;
    private readonly InputAction m_Teclado_Disparar;
    private readonly InputAction m_Teclado_CambiarColor;
    public struct TecladoActions
    {
        private @InputActionsGameplay m_Wrapper;
        public TecladoActions(@InputActionsGameplay wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Teclado_Mover;
        public InputAction @Disparar => m_Wrapper.m_Teclado_Disparar;
        public InputAction @CambiarColor => m_Wrapper.m_Teclado_CambiarColor;
        public InputActionMap Get() { return m_Wrapper.m_Teclado; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TecladoActions set) { return set.Get(); }
        public void SetCallbacks(ITecladoActions instance)
        {
            if (m_Wrapper.m_TecladoActionsCallbackInterface != null)
            {
                @Mover.started -= m_Wrapper.m_TecladoActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_TecladoActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_TecladoActionsCallbackInterface.OnMover;
                @Disparar.started -= m_Wrapper.m_TecladoActionsCallbackInterface.OnDisparar;
                @Disparar.performed -= m_Wrapper.m_TecladoActionsCallbackInterface.OnDisparar;
                @Disparar.canceled -= m_Wrapper.m_TecladoActionsCallbackInterface.OnDisparar;
                @CambiarColor.started -= m_Wrapper.m_TecladoActionsCallbackInterface.OnCambiarColor;
                @CambiarColor.performed -= m_Wrapper.m_TecladoActionsCallbackInterface.OnCambiarColor;
                @CambiarColor.canceled -= m_Wrapper.m_TecladoActionsCallbackInterface.OnCambiarColor;
            }
            m_Wrapper.m_TecladoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
                @Disparar.started += instance.OnDisparar;
                @Disparar.performed += instance.OnDisparar;
                @Disparar.canceled += instance.OnDisparar;
                @CambiarColor.started += instance.OnCambiarColor;
                @CambiarColor.performed += instance.OnCambiarColor;
                @CambiarColor.canceled += instance.OnCambiarColor;
            }
        }
    }
    public TecladoActions @Teclado => new TecladoActions(this);
    public interface ITecladoActions
    {
        void OnMover(InputAction.CallbackContext context);
        void OnDisparar(InputAction.CallbackContext context);
        void OnCambiarColor(InputAction.CallbackContext context);
    }
}
