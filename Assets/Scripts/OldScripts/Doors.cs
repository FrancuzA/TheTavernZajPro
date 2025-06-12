using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class Doors : MonoBehaviour, IInteractable
{
    
    bool doorsOpened = true;
    bool isRotating = false;
    public Animator DoorAnim;
    public bool isInRoom;


    public void SetIsInRoom(bool value)
    {
        isInRoom = value;
    }

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
    void RoomsSnap()
    {
        InsideRoom = FMODUnity.RuntimeManager.CreateInstance(insideRoomSnap);
        if (isInRoom)
        {
            InsideRoom.start();
            InsideRoom.release();
        }
        else
        {
            InsideRoom.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
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
            RoomsSnap();
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



