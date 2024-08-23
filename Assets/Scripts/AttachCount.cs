using UnityEngine;

public class AttachCount : MonoBehaviour
{
    public int value = 0; 

    private void OnTriggerEnter(Collider other)
    {
        value = 1;
    }

    private void OnTriggerStay(Collider other)
    {
        value = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        value = 0;
    }
}
