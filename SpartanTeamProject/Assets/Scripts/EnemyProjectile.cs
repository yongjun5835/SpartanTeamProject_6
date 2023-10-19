using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float m_Speed = 10;
    public float m_HeightArc = 1;
    public Transform m_Target;
    private Vector3 m_StartPosition;

    private void Start()
    {
        m_StartPosition = transform.position;
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;

        float x0 = m_StartPosition.x;
        float x1 = m_Target.position.x;
        float distance = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, m_Speed * Time.deltaTime);
        float baseY = Mathf.Lerp(m_StartPosition.y, m_Target.position.y, (nextX - x0) / distance);
        float arc = m_HeightArc * (nextX - x0) * (nextX - x1) / (-0.25f * distance * distance);
        Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);

        transform.rotation = LookAt2D(nextPosition - transform.position);
        transform.position = nextPosition;
    }

    Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Destroy(this.gameObject);
    }

}
