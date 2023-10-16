using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    public Transform Target { get; private set; }

    public EnemyIdleState IdleState { get; }
    public EnemyChasingState ChasingState { get; }
    public EnemyAttackState AttackState { get; }

    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        //idlestate = new enemyidlestate(this);
        //chasingstate = new enemychasingstate(this);
        //attackstate = new enemyattackstate(this);

        MovementSpeed = enemy.Data.BaseSpeed;
    }
}
