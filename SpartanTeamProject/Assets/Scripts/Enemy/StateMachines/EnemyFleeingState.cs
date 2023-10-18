using UnityEngine;

public class EnemyFleeingState : EnemyGroundState
{
    private Vector3 direction;
    public EnemyFleeingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimData.WalkParameterHash);
        direction = GetMovementDirection();
    }
    protected override Vector3 GetMovementDirection()
    {
        return (stateMachine.Enemy.transform.position - stateMachine.Target.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
