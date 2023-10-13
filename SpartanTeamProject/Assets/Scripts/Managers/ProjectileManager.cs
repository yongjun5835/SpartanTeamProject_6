using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;
    public PlayerController playerController;
    [SerializeField]
    private Transform projectileSpawnPoint;
    [Header("# Projectiles")]
    public GameObject defaultProjectile;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(this.gameObject);
    }

    public void Shoot()
    {
        Vector3 dir = Quaternion.AngleAxis(playerController.aimAngle, Vector3.forward) * Vector3.right;
        defaultProjectile.GetComponent<Rigidbody2D>().AddForce(dir * playerController.currentPower / 5, ForceMode2D.Impulse);
    }
}
