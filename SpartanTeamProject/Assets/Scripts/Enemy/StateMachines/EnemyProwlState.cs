using UnityEngine;

public class EnemyProwlState : EnemyGroundState
{
    private Vector3 direction = Vector3.zero;

    public EnemyProwlState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 1f;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimData.WalkParameterHash);
        direction = GetMovementDirection();
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
        if (baseTimer >= 2f)
        {
            baseTimer = 0f;
            OnIdle();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();        
    }

    protected override void Move()
    {
        if(direction.x >= 0)
        {
            stateMachine.Enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            stateMachine.Enemy.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        Move(direction);
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
        Debug.Log("πÊ«‚" + direction);
        float movementSpeed = GetMovementSpeed();
        Vector2 movePos = new Vector2(direction.x, 0f);
        Vector2 goalPos = stateMachine.Enemy._Rigidbody.position + movePos;
        Vector2 lerpPos = Vector2.Lerp(stateMachine.Enemy._Rigidbody.position, goalPos, movementSpeed * Time.deltaTime);
        stateMachine.Enemy._Rigidbody.MovePosition(lerpPos);        
    }
}
