using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;
    public PlayerController playerController;
    [SerializeField]
    private Transform projectileSpawnPoint;
    [Header("# Projectiles")]
    [SerializeField]
    private GameObject[] projectiles;

    private GameObject selectedProjectile;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(this.gameObject);

        selectedProjectile = projectiles[0];
    }

    public void Shoot()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        projectileSpawnPoint = GameObject.FindGameObjectWithTag("ProjectileSpawnPoint").transform;
        GameObject projectile = Instantiate(selectedProjectile, projectileSpawnPoint.position, Quaternion.AngleAxis(playerController.aimAngle, Vector3.forward));
        GameManager.Instance.cameraController.SetTarget(projectile.transform);
        Vector3 dir = Quaternion.AngleAxis(playerController.aimAngle, Vector3.forward) * Vector3.right;
        float shootPower = playerController.currentPower / 5;
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * shootPower, ForceMode2D.Impulse);
        Debug.Log($"shootPoewr: {shootPower}");
    }

    public void selectBtn(string tag)
    {
        if (tag == "Weapon_Default")
            selectedProjectile = projectiles[0];
        else
            selectedProjectile = projectiles[int.Parse(tag[13].ToString())];

        Debug.Log(selectedProjectile);
    }
    public void EnemyShoot( int i, float shootPower, Vector3 shootTip)
    {
        Debug.Log("���� ȣ���?6");
        GameObject projectile = Instantiate(projectiles[0], shootTip, Quaternion.AngleAxis(40f, Vector3.forward));
        GameManager.Instance.cameraController.SetTarget(projectile.transform);
        Vector3 dir = Quaternion.AngleAxis(40f, Vector3.forward) * Vector3.right;
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * shootPower, ForceMode2D.Impulse);
        Debug.Log($"shootPoewr: {shootPower}");
    }
}
