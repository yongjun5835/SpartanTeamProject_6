using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected IState curState;

    public void ChangeState(IState newState)
    {
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
