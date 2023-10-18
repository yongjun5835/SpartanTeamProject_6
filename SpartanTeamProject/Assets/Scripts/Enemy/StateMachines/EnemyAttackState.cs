
using UnityEngine;

public class EnemyAttackState : EnemyGroundState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    public override void Enter()
    {
        Debug.Log("ø©±‚ »£√‚µ≈?1");
        base.Enter();
        Debug.Log("ø©±‚ »£√‚µ≈?2");
        stateMachine.Enemy.Animator.SetTrigger(stateMachine.Enemy.AnimData.AttackParameterHash);
        Debug.Log("ø©±‚ »£√‚µ≈?3");
        ProjectileManager.instance.EnemyShoot(0, 10f, stateMachine.Enemy.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
