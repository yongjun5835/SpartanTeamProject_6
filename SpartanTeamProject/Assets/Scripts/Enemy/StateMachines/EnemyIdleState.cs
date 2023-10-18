
public class EnemyIdleState : EnemyGroundState
{    
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        // TODO
        // if (turn == enemy && timer > 2f)
        // timer = 0;
        // onprowl()
        // 
    }  
}
