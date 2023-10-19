using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly EnemySO data;

    protected float baseTimer = 0;

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
        baseTimer += Time.deltaTime;        

        if (!stateMachine.Enemy.IsMyTurn)
        {
            OnIdle();
            return;
        }   

        switch (TargetPosInRange())
        {
            case TargetPos.NotInRange:
                OnProwl();                
                break;
            case TargetPos.ChaseRange:
                OnChasing();
                break;
            case TargetPos.AttackRange:
                OnAttack();
                break;
        }
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
                
        if (playerDistanceSqr <= stateMachine.Enemy.Data.AttackRange * stateMachine.Enemy.Data.AttackRange)
        {
            targetPos = TargetPos.AttackRange;
        }
        //else if (playerDistanceSqr <= stateMachine.Enemy.Data.ChasingRange * stateMachine.Enemy.Data.ChasingRange)
        //{
        //    targetPos = TargetPos.ChaseRange;
        //} 
        else
        {
            targetPos = TargetPos.NotInRange;
        }

        return targetPos;
    }
    protected void OnIdle()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
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

    protected void CallEnemyShoot()
    {
        Debug.Log("¿©±â È£ÃâµÅ?5");
        stateMachine.Enemy.EnemyShoot();
    }
}
