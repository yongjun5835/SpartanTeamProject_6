using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float drag = 0.3f;

    private Vector3 dampingVelocity;
    private Vector3 impact;

    void Update()
    {      
        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity,drag);
    }

    private void Reset()
    {
        impact = Vector3.zero;
    }

    public void AddForce(Vector3 force)
    {
        impact += force;
    }
}
