using UnityEngine;
using UnityEngine.Events;

public class RoomTrigger : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnLeave;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLeave?.Invoke();
        }
    }
}
