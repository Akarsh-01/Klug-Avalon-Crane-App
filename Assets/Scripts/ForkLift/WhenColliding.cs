using UnityEngine;
using UnityEngine.InputSystem;

public class WhenColliding : MonoBehaviour
{
    private GameObject attachedObject;
    [SerializeField] private bool isObjectAttached = false;
    private InputControls inputActions; 

    private void Awake()
    {
        inputActions = new InputControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable(); 
    }

    private void Start()
    {
        inputActions.Forklift.ForkEnter.performed += ctx => ToggleObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        attachedObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isObjectAttached && attachedObject == other.gameObject)
        {
            attachedObject = null;
        }
    }

    private void ToggleObject()
    {
        if (attachedObject != null)
        {
            if (isObjectAttached)
            {
                DetachObject();
            }
            else
            {
                AttachObject();
            }
        }
    }

    private void AttachObject()
    {
        attachedObject.transform.SetParent(transform);

        Vector3 scale = attachedObject.transform.localScale;

        if (Mathf.Approximately(scale.x, 0.5f))
        {
            attachedObject.transform.localPosition = new Vector3(0, 0, -0.25f);
        }
        else if (Mathf.Approximately(scale.x, 1f))
        {
            attachedObject.transform.localPosition = new Vector3(0, -0.25f, 0);
        }

        attachedObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        Rigidbody rb = attachedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }

        isObjectAttached = true;
    }

    private void DetachObject()
    {
        attachedObject.transform.SetParent(null);

        Rigidbody rb = attachedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true; 
        }

        isObjectAttached = false;

        attachedObject = null; 
    }
}
