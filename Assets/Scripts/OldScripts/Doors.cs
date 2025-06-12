using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class Doors : MonoBehaviour, IInteractable
{
    
    bool doorsOpened = true;
    bool isRotating = false;
    public Animator DoorAnim;
    public bool isInRoom;


    ////////////////// FMOD Section ///////////////////

    // Door's sample //
    FMOD.Studio.EventInstance DoorsSound;
    public EventReference DoorsEvent;
    
    // Room's Snapshot //
    FMOD.Studio.EventInstance InsideRoom;
    public EventReference insideRoomSnap;

    ////////////////// FMOD Section End ///////////////////

    public void Interact()
    {
        if (!isRotating)
        {
            DoorsInteract();
        }
    }

    public void SetIsInRoom(bool value)
    {
        isInRoom = value;
    }
    void RoomsSnap()
    {
        InsideRoom = FMODUnity.RuntimeManager.CreateInstance(insideRoomSnap);
        if (isInRoom)
        {
            Debug.Log("TurningMusicOf");
            InsideRoom.start();
            InsideRoom.release();
        }
        else
        {
            InsideRoom.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            InsideRoom.release();
        }
    }

    void DoorsInteract()
    {
        if (doorsOpened == true)
        {
            DoorAnim.SetTrigger("Close");
            doorsOpened = false;
            RoomsSnap();
        }
        else
        {
            DoorAnim.SetTrigger("Open");
            doorsOpened = true;
            Debug.Log("Turning music on");
            InsideRoom.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            InsideRoom.release();
        }
    }

    public void PlaySoundOpen()
    {
        DoorsSound = FMODUnity.RuntimeManager.CreateInstance(DoorsEvent);
        DoorsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        DoorsSound.setParameterByName("doorControler", 0);
        DoorsSound.start();
        DoorsSound.release();
    }

    public void PlaySoundClose()
    {
        DoorsSound = FMODUnity.RuntimeManager.CreateInstance(DoorsEvent);
        DoorsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        DoorsSound.setParameterByName("doorControler", 1);
        DoorsSound.start();
        DoorsSound.release();
    }


}



