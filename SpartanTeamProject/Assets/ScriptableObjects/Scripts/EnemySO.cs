using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float BaseSpeed { get; private set; } = 2f;
    [field: SerializeField] public float RunSpeedModifier { get; private set; } = 1.5f;
    [field: SerializeField] public float ChasingRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; } 
    [field: SerializeField] public float FleeingRange { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float AttackDelay { get; private set; }
    [field: SerializeField] public float Dealing_Start_TransitionTime { get; private set; }
    [field: SerializeField] public float Dealing_End_TransitionTime { get; private set; }
}