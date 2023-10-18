using UnityEngine;

public class EnemyChasingState : EnemyGroundState
{
    private Vector3 direction;

    public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = stateMachine.Enemy.Data.RunSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimData.RunParameterHash);
        direction = GetMovementDirection();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimData.RunParameterHash);
    }
    public override void Update()
    {
        base.Update();
        Move();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void Move()
    {
        if (direction.x >= 0)
        {
            stateMachine.Enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        Move(direction);
    }


    protected override Vector3 GetMovementDirection()
    {
        return (stateMachine.Target.transform.position - stateMachine.Enemy.transform.position).normalized;
    }

    protected override void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        Vector2 movePos = new Vector2(direction.x, 0f);
        Vector2 goalPos = stateMachine.Enemy._Rigidbody.position + movePos;
        Vector2 lerpPos = Vector2.Lerp(stateMachine.Enemy._Rigidbody.position, goalPos, movementSpeed * Time.deltaTime);
        stateMachine.Enemy._Rigidbody.MovePosition(lerpPos);
    }

}
