using UnityEngine;
public class EnemyAttackState : EnemyGroundState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateMachine.Enemy.Animator.SetTrigger(stateMachine.Enemy.AnimData.AttackParameterHash);
        Debug.Log("ø©±‚ »£√‚µ≈?0");
        CallEnemyShoot();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
