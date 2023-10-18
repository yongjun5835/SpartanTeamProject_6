using UnityEngine;

public class EnemyIdleState : EnemyGroundState
{
    protected float idleTime;

    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        idleTime = 0f;
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
        idleTime += Time.deltaTime;
        if (idleTime < 2f)
            return;
        base.Update();
    }  
}
