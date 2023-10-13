using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("# References")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("# Animations")]
    [field: SerializeField] public EnemyAnimationData animData { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController controller { get; private set; }

    private EnemyStateMachine stateMachine;

    private void Awake()
    {
        animData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.idleState);
    }

}
