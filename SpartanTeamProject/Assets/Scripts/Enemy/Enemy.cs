
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

    private float maxHealth;
    public float curHealth;

    private void Awake()
    {
        maxHealth = Data.Health;

        AnimData.Initialize();
        _Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        stateMachine = new EnemyStateMachine(this);
    }

    private void Start()
    {
        curHealth = maxHealth;
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

    public void TakenDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth < 0)
        {
            Animator.SetTrigger(AnimData.DeadParameterHash);
            Destroy(gameObject);
        }
    }
}
