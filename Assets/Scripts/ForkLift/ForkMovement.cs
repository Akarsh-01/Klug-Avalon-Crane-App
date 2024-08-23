using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class forkMovement : MonoBehaviour
{
    private InputControls input;
    public float forkValue;
    
    // Start is called before the first frame update
    private void Awake()
    {
        input = new InputControls();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Forklift.ForkMove.performed += OnMovementPerformed;
        input.Forklift.ForkMove.canceled += OnMovementCancelled;

    }
    private void OnDisable()
    {
        input.Disable();
        input.Forklift.ForkMove.performed -= OnMovementPerformed;
        input.Forklift.ForkMove.canceled -= OnMovementCancelled;
    }
    //private void FixedUpdate()
    //{
    //    Debug.Log(moveVector);
    //}
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        forkValue = value.ReadValue<float>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        forkValue = 0f;
    }
}