
public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly EnemySO data;

    public EnemyBaseState(EnemyStateMachine EnemyStateMachine)
    {
        stateMachine = EnemyStateMachine;
        data = stateMachine.enemy.Data;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void PhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
