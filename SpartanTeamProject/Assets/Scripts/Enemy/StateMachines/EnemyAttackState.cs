
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
        ProjectileManager.instance.EnemyShoot(stateMachine.Enemy.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
