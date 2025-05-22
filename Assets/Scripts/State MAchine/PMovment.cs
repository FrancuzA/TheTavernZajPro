using UnityEngine;

public class PMovment: StateMachine
{
    
    private void Start()
    {
        Begin(new PlayerGroundedState(this));

    }
}
