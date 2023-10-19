using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public IState curState { get; private set; }

    public void ChangeState(IState newState)
    {
        if (curState == newState)
            return;

        curState?.Exit();
        curState = newState;
        curState?.Enter();
    }

    public void Update()
    {
        curState?.Update();
    }

    public void PhysicsUpdate()
    {
        curState?.PhysicsUpdate();
    }
}
