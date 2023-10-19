
using System;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: Header("# References")]
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("# Animations")]
    [field: SerializeField] public EnemyAnimationData AnimData { get; private set; }

    public Rigidbody2D _Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    public event Action OnHealthChange;

    private EnemyStateMachine stateMachine;

    public bool IsMyTurn = false;

    public float maxHealth;
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
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    } 

    public void TakenDamage(float damage)
    {
        curHealth -= damage;
        if( curHealth >= 0) CallHpChanged();
        if (curHealth < 0)
        {
            Animator.SetTrigger(AnimData.DeadParameterHash);
            Destroy(gameObject, 1.5f);
        }

    }
    public void CallHpChanged()
    {
        OnHealthChange?.Invoke();
    }

    public void EnemyShoot()
    {
        Debug.Log("¿©±â È£ÃâµÅ?1");
        Debug.Log(Data.projectile);
        Debug.Log(transform.position);
        Instantiate(Data.projectile, transform.position, Quaternion.identity);
    }
}
