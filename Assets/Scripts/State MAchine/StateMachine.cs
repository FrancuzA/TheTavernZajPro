using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private StateStack _stack;
    public State CurrentState { get; private set; }
    private State _PreviousState;
    public void Begin(State state)
    {
        _stack = new StateStack();
        _stack.Push(state);
        CurrentState = state;
        CurrentState.Enter();
    }

    public void SetState(State state)
    {
        Debug.Log("Setting new state");

        if (CurrentState != null) { CurrentState.Exit(); }

        CurrentState = state;
        _stack.Push(state);
        Debug.Log("new state set " +  CurrentState.ToString()); 
        CurrentState.Enter();
    }

    public void Dispose()
    {
        if (_stack.Count() == 0)
            return;

        CurrentState.Exit();
        CurrentState = null;
        _stack.Pop();

        if (_stack.Count() == 0)
            return;

        CurrentState = _stack.Peek();
        CurrentState.Enter();
    }

    private void Update()
    {
        if (CurrentState == null)
        {
            Debug.Log("no current state");
            return;
        }


        CurrentState.Update();
    }
}
