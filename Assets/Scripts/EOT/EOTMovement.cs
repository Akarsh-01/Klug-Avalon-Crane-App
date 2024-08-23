using UnityEngine;
using UnityEngine.InputSystem;

public class EOTMovement : MonoBehaviour
{
    private InputControls buttonMove;

    public float button1Value=0;
    public float button2Value=0;
    public float eotValue = 0;

    private void Awake()
    {
        buttonMove = new InputControls();
    }

    void OnEnable()
    {
        buttonMove.Enable();

        buttonMove.EOT.Adjustment.performed += OnButton1Pressed;
        buttonMove.EOT.Adjustment.canceled += OnButton1Released;

        buttonMove.EOT.Grab.performed += OnButton2Performed;
        buttonMove.EOT.Grab.canceled += OnButton2Canceled;

        buttonMove.EOT.EOTMove.performed += OnEOTMovementPerformed;
        buttonMove.EOT.EOTMove.canceled += OnEOTMovementCanceled;

    }

    void OnDisable()
    {
        buttonMove.Disable();

        buttonMove.EOT.Adjustment.performed -= OnButton1Pressed;
        buttonMove.EOT.Adjustment.canceled -= OnButton1Released;

        buttonMove.EOT.Grab.performed -= OnButton2Performed;
        buttonMove.EOT.Grab.canceled -= OnButton2Canceled;

        buttonMove.EOT.EOTMove.performed -= OnEOTMovementPerformed;
        buttonMove.EOT.EOTMove.canceled -= OnEOTMovementCanceled;
    }

    private void OnButton1Pressed(InputAction.CallbackContext context)
    {
        button1Value = context.ReadValue<float>();
        Debug.Log($"Button 1 pressed with value: {button1Value}");
    }

    private void OnButton1Released(InputAction.CallbackContext context)
    {
        button1Value = context.ReadValue<float>();
        Debug.Log($"Button 1 released with value: {button1Value}");
    }

    private void OnButton2Performed(InputAction.CallbackContext context)
    {
        button2Value = context.ReadValue<float>();
        Debug.Log($"Button 2 performed with value: {button2Value}");
    }

    private void OnButton2Canceled(InputAction.CallbackContext context)
    {
        button2Value = context.ReadValue<float>();
        Debug.Log($"Button 2 canceled with value: {button2Value}");
    }

    private void OnEOTMovementPerformed(InputAction.CallbackContext context)
    {
        eotValue = context.ReadValue<float>();
        Debug.Log($"Movement performed with value: {eotValue}");
    }

    private void OnEOTMovementCanceled(InputAction.CallbackContext context)
    {
        eotValue = context.ReadValue<float>();
        Debug.Log($"Movement canceled with value: {eotValue}");
    }
}