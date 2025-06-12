
using FMODUnity;
using UnityEngine;

public class AmbientChanger : MonoBehaviour
{
    public GameObject InsideAmbient;
    public StudioEventEmitter OutsideAmbient;


    private void Start()
    {
        OutsideAmbient = gameObject.GetComponent<StudioEventEmitter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InsideAmbient.SetActive(false);
            OutsideAmbient.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InsideAmbient.SetActive(!false);
            OutsideAmbient.enabled = !true;
        }
    }
}
