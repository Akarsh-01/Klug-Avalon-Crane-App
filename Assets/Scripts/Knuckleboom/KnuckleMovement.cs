using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnuckleMovement : MonoBehaviour
{
    private InputControls buttonMove;

    [SerializeField] private float button1Value = 0;
    [SerializeField] private float button2Value = 0;
    [SerializeField] private float knuckleValue = 0;

    private void Awake()
    {
        buttonMove = new InputControls();
    }

    void OnEnable()
    {
        buttonMove.Enable();

        buttonMove.Knuckleboom.Knuckle.performed += OnButton1Pressed;
        buttonMove.Knuckleboom.Knuckle.canceled += OnButton1Released;

        buttonMove.Knuckleboom.Stabilize.performed += OnButton2Performed;
        buttonMove.Knuckleboom.Stabilize.canceled += OnButton2Canceled;

        buttonMove.Knuckleboom.KnuckleMove.performed += OnEOTMovementPerformed;
        buttonMove.Knuckleboom.KnuckleMove.canceled += OnEOTMovementCanceled;

    }

    void OnDisable()
    {
        buttonMove.Disable();

        buttonMove.Knuckleboom.Knuckle.performed -= OnButton1Pressed;
        buttonMove.Knuckleboom.Knuckle.canceled -= OnButton1Released;

        buttonMove.Knuckleboom.Stabilize.performed -= OnButton2Performed;
        buttonMove.Knuckleboom.Stabilize.canceled -= OnButton2Canceled;

        buttonMove.Knuckleboom.KnuckleMove.performed -= OnEOTMovementPerformed;
        buttonMove.Knuckleboom.KnuckleMove.canceled -= OnEOTMovementCanceled;
    }

    private void OnButton1Pressed(InputAction.CallbackContext context)
    {
        button1Value = context.ReadValue<float>();
        //Debug.Log($"Button 1 pressed with value: {button1Value}");
    }

    private void OnButton1Released(InputAction.CallbackContext context)
    {
        button1Value = context.ReadValue<float>();
        //Debug.Log($"Button 1 released with value: {button1Value}");
    }

    private void OnButton2Performed(InputAction.CallbackContext context)
    {
        button2Value = context.ReadValue<float>();
        //Debug.Log($"Button 2 performed with value: {button2Value}");
    }

    private void OnButton2Canceled(InputAction.CallbackContext context)
    {
        button2Value = context.ReadValue<float>();
        //Debug.Log($"Button 2 canceled with value: {button2Value}");
    }

    private void OnEOTMovementPerformed(InputAction.CallbackContext context)
    {
        knuckleValue = context.ReadValue<float>();
        //Debug.Log($"Movement performed with value: {knuckleValue}");
    }

    private void OnEOTMovementCanceled(InputAction.CallbackContext context)
    {
        knuckleValue = context.ReadValue<float>();
        //Debug.Log($"Movement canceled with value: {knuckleValue}");
    }
    public float GetButton1Value()
    {
        return button1Value;
    }

    public float GetButton2Value()
    {
        return button2Value;
    }

    public float GetKnuckleValue()
    {
        return knuckleValue;
    }

}