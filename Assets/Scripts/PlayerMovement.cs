using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputControls input;
    public Vector2 moveVector;
    // Start is called before the first frame update
    private void Awake()
    {
        input=new InputControls();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Controls.Movement.performed += OnMovementPerformed;
        input.Controls.Movement.canceled += OnMovementCancelled;



    }
    private void OnDisable()
    {
        input.Disable();
        input.Controls.Movement.performed -= OnMovementPerformed;
        input.Controls.Movement.canceled -= OnMovementCancelled;
    }
    //private void FixedUpdate()
    //{
    //    Debug.Log(moveVector);
    //}
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector= value.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
