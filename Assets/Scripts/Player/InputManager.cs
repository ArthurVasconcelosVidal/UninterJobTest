using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour{
    
    PlayerInput playerInput;

    [Header("Stick values (DEBUG)")]
    [SerializeField] Vector2 stickValue = Vector2.zero;

    public event EventHandler<InputAction.CallbackContext> 
    OnActionButtonPerformed, OnActionButtonCanceled;

    public Vector2 StickValue { get => stickValue; }

    void Awake() {
        playerInput = new PlayerInput();
        StickConfiguration();
        ActionButtonPerformedConfig();
        ActionButtonCanceledConfig();
    }

    void StickConfiguration(){
        playerInput.PlayerActions.LeftStick.performed += ContextMenu => {
            stickValue = ContextMenu.ReadValue<Vector2>();
            stickValue = stickValue.normalized * stickValue.sqrMagnitude;
        };
        playerInput.PlayerActions.LeftStick.canceled += ContextMenu => {
            stickValue = Vector2.zero;
        };
    }

    void ActionButtonPerformedConfig(){
        playerInput.PlayerActions.SouthButton.performed += ContextMenu => OnActionButtonPerformed?.Invoke(this,ContextMenu);
    }

    void ActionButtonCanceledConfig(){
        playerInput.PlayerActions.SouthButton.canceled += ContextMenu => OnActionButtonCanceled?.Invoke(this,ContextMenu);
    }

    void OnEnable() {
        playerInput.Enable();
    }

    void OnDisable() {
        playerInput.Disable();
    }
}
