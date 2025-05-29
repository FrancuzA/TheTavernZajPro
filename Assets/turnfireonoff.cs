using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnfireonoff : MonoBehaviour
{
    public GameObject fire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fire.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fire.SetActive(false);
        }
    }
}
