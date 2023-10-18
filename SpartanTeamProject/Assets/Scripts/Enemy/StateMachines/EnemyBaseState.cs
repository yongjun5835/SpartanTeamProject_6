using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly EnemySO data;

    protected enum TargetPos
    {
        NotInRange, ChaseRange, AttackRange, FleeRange
    }
    protected TargetPos targetPos;

    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        stateMachine = enemyStateMachine;
        data = stateMachine.Enemy.Data;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {
       
    }
    public virtual void Update()
    {       
        // TODO
        // 내 턴이면서
        // 플레이어가 감지되지 않을 때 - OnProwl
        // 플레이어가 attack range - attack
        // 플레이어가 chasing range - chasing
        // 플레이어가 fleeing range - fleeing

        //switch (TargetPosInRange())
        //{
        //    case TargetPos.NotInRange:
        //        OnProwl();
        //        break;
        //    case TargetPos.ChaseRange:
        //        OnChasing();
        //        break;
        //    case TargetPos.AttackRange:
        //        OnAttack();
        //        break;
        //    case TargetPos.FleeRange:
        //        OnFleeing();
        //        break;
        //}
    }   

    public virtual void PhysicsUpdate()
    {
       
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Enemy.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Enemy.Animator.SetBool(animationHash, false);
    }  
    
    protected virtual void Move()
    {
        
    }

    protected virtual Vector3 GetMovementDirection()
    {        
        return Vector3.zero;
    }

    protected virtual void Move(Vector3 direction)
    {
        
    }

    protected virtual float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;

        return movementSpeed;
    }
    protected TargetPos TargetPosInRange()
    {
        Vector3 playerPos = stateMachine.Target.transform.position;
        Vector3 enemyPos = stateMachine.Enemy.transform.position;
        TargetPos targetPos;

        float playerDistanceSqr = (playerPos - enemyPos).sqrMagnitude;

        if (playerDistanceSqr <= stateMachine.Enemy.Data.ChasingRange * stateMachine.Enemy.Data.ChasingRange)
        {
            targetPos = TargetPos.ChaseRange;

            if (playerDistanceSqr <= stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange)
            {
                targetPos = TargetPos.AttackRange;

                if (playerDistanceSqr <= stateMachine.Enemy.Data.FleeingRange * stateMachine.Enemy.Data.FleeingRange)
                {
                    targetPos = TargetPos.FleeRange;
                }
            }
        }
        else
        {
            targetPos = TargetPos.NotInRange;
        }

        return targetPos;
    }
    protected void OnProwl()
    {
        stateMachine.ChangeState(stateMachine.ProwlState);
    }

    protected void OnChasing()
    {
        stateMachine.ChangeState(stateMachine.ChasingState);
    }

    protected void OnAttack()
    {
        stateMachine.ChangeState(stateMachine.AttackState);
    }

    protected void OnFleeing()
    {
        stateMachine.ChangeState(stateMachine.FleeingState);
    }
}
