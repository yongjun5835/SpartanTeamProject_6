
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("# References")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("# Animations")]
    [field: SerializeField] public EnemyAnimationData AnimData { get; private set; }

    public Rigidbody2D _Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    private EnemyStateMachine stateMachine;

    public bool IsMyTurn = false;

    private void Awake()
    {
        AnimData.Initialize();
        _Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Update();
        Debug.Log("현재 상태" + stateMachine.curState.ToString());
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    } 
}
