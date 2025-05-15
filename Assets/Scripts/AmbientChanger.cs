
using UnityEngine;

public class AmbientChanger : MonoBehaviour
{
    public GameObject InsideAmbient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InsideAmbient.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InsideAmbient.SetActive(!false);
        }
    }
}
