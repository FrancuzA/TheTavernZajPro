using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour, IInteractable
{
    FMOD.Studio.EventInstance ExplSound;
    public EventReference ExplEvent;
    FMOD.Studio.EventInstance StunSound;
    public EventReference StunEvent;
    public GameObject ExplVFX;
    public void Interact()
    {
        Debug.Log("boom;");
        StartCoroutine(Boom());
    }

    private IEnumerator  Boom()
    {
        ExplSound = FMODUnity.RuntimeManager.CreateInstance(ExplEvent);
        StunSound = FMODUnity.RuntimeManager.CreateInstance(StunEvent);
        ExplSound.start();
        ExplSound.release();
        yield return new WaitForSeconds(2f);
        StunSound.start();
        StunSound.release();
        yield return new WaitForSeconds(5);
        StunSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        yield return null;
    }
}
