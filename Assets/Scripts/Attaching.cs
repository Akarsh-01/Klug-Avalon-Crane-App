using UnityEngine;

public class AttachOnEnter : MonoBehaviour
{
    private GameObject attachedObject;
    public AttachCount attachCount;
    [SerializeField]private bool isObjectAttached = false;
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
        inputActions.EOT.EOTEnter.performed += ctx => ToggleObject();
    }


    void OnTriggerEnter(Collider other)
    {
        attachedObject = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (!isObjectAttached && attachedObject == other.gameObject)
        {
            attachedObject = null;
        }
    }
   

    void ToggleObject()
    {
      //  if (Input.GetKeyDown(KeyCode.Return))
      //  {
            if (attachedObject != null)
            {
                if (isObjectAttached && attachCount.value==1 )
                {
                    DetachObject();
                }
                else if(!isObjectAttached && attachCount.value==1)
                {
                    AttachObject();
                }
            }
       // }
    }

    void AttachObject()
    {
        attachedObject.transform.SetParent(transform);

        Rigidbody rb = attachedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
        }

        isObjectAttached = true;
    }

    void DetachObject()
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