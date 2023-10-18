
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("# References")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("# Animations")]
    [field: SerializeField] public EnemyAnimationData AnimData { get; private set; }

    public Rigidbody2D _Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    private EnemyStateMachine stateMachine;

    private void Awake()
    {
        AnimData.Initialize();
        _Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        ForceReceiver = GetComponent<ForceReceiver>();

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.ChasingState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    } 
}
