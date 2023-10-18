using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    public Transform Target { get; private set; }

    public EnemyIdleState IdleState { get; }
    public EnemyProwlState ProwlState { get; }
    public EnemyChasingState ChasingState { get; }
    public EnemyAttackState AttackState { get; }
    public EnemyFleeingState FleeingState { get; }

    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdleState = new EnemyIdleState(this);
        ProwlState = new EnemyProwlState(this);
        ChasingState = new EnemyChasingState(this);
        AttackState = new EnemyAttackState(this);
        FleeingState = new EnemyFleeingState(this);
        MovementSpeed = enemy.Data.BaseSpeed;
    }
}
