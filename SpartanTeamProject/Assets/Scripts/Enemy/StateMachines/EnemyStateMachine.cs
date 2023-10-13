using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy enemy { get; }

    public Transform Target { get; private set; }

    public EnemyIdleState idleState { get; }

    public float MovementSpeed { get; private set; }

    public EnemyStateMachine(Enemy enemy)
    {
        this.enemy = enemy;

        // idleState = new EnemyIdleState(this);

        MovementSpeed = enemy.Data.BaseSpeed;
    }
}
