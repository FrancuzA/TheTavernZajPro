using UnityEngine;

public class MusicSwitch : MonoBehaviour, IInteractable
{
    public FMODUnity.StudioEventEmitter tavernEmitter;

    public void Interact()
    {
        switch (gameObject.name)
        {
            case "Food_bottle1":
                tavernEmitter.SetParameter("MusicSection", 0);
                break;
            case "Food_bottle2":
                tavernEmitter.SetParameter("MusicSection", 1);
                break;
            case "Food_bottle3":
                tavernEmitter.SetParameter("MusicSection", 2);
                break;
            case "Food_bottle4":
                tavernEmitter.SetParameter("MusicSection", 3);
                break;
            case "Food_bottle5":
                tavernEmitter.SetParameter("MusicSection", 4);
                break;
            case "Food_bottle6":
                tavernEmitter.SetParameter("MusicSection", 0);
                break;
        }
    }
}
