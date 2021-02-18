using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class Jump1InputEvent : UnityEvent<bool> {}
[Serializable]
public class Move1InputEvent : UnityEvent<float> {}
[Serializable]
public class Jump2InputEvent : UnityEvent<bool> {}
[Serializable]
public class Move2InputEvent : UnityEvent<float> {}
public class InputManager : MonoBehaviour
{

    Controls controls;
    public Jump1InputEvent jump1InputEvent;
    public Move1InputEvent move1InputEvent;
    public Jump2InputEvent jump2InputEvent;
    public Move2InputEvent move2InputEvent;
    

    void Awake() {
        controls = new Controls();
    }

    void OnEnable() {
        controls.Player.Enable();
        controls.Player2.Enable();
        controls.Player.Jump.performed += OnPlayer1JumpPerformed;
        controls.Player.Move.performed += OnPlayer1MovePerformed;
        controls.Player.Move.canceled += OnPlayer1MovePerformed;
        controls.Player2.Jump.performed += OnPlayer2JumpPerformed;
        controls.Player2.Move.performed += OnPlayer2MovePerformed;
        controls.Player2.Move.canceled += OnPlayer2MovePerformed;
    }

    private void OnPlayer1JumpPerformed(InputAction.CallbackContext context) {
        jump1InputEvent.Invoke(true);
    }

    private void OnPlayer1MovePerformed(InputAction.CallbackContext context) {
        float moveInput = context.ReadValue<float>();
        move1InputEvent.Invoke(moveInput);
    }

    private void OnPlayer2JumpPerformed(InputAction.CallbackContext context) {
        jump2InputEvent.Invoke(true);
    }

    private void OnPlayer2MovePerformed(InputAction.CallbackContext context) {
        float moveInput = context.ReadValue<float>();
        move2InputEvent.Invoke(moveInput);
    }
}
