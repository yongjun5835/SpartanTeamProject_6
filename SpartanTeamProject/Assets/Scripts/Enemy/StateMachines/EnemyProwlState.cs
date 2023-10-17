
using UnityEngine;

public class EnemyProwlState : EnemyGroundState
{
    public EnemyProwlState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimData.WalkParameterHash);
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
        Vector3 movementDirection = GetMovementDirection();
        if(movementDirection == Vector3.right)
        {
            stateMachine.Enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        Move(movementDirection);
    }

    protected override Vector3 GetMovementDirection()
    {
        int ranIndex = Random.Range(0, 2);
        if (ranIndex == 0)
            return Vector3.right;
        else
            return Vector3.left;
    }
    protected override void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        Debug.Log(direction);
        stateMachine.Enemy._Rigidbody.MovePosition((direction * movementSpeed) * Time.fixedDeltaTime);
    }  
}
