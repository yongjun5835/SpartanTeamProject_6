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
    [Header("# Weapon Btn")]
    public Button[] weapons;

    private GameObject slectedProjectile;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(this.gameObject);

        slectedProjectile = projectiles[0];
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(slectedProjectile, projectileSpawnPoint.position, Quaternion.AngleAxis(playerController.aimAngle, Vector3.forward));
        Vector3 dir = Quaternion.AngleAxis(playerController.aimAngle, Vector3.forward) * Vector3.right;
        float shootPower = playerController.currentPower / 5;
        projectile.GetComponent<Rigidbody2D>().AddForce(dir * shootPower, ForceMode2D.Impulse);
        Debug.Log($"shootPoewr: {shootPower}");
    }

    public void selectBtn(int i)
    {
        if (weapons[i].tag == "Weapon_Default")
            slectedProjectile = projectiles[0];
        else
            slectedProjectile = projectiles[int.Parse(weapons[i].tag[13].ToString())];
    }

    public void selectBtn1()
    {
        selectBtn(0);
    }

    public void selectBtn2()
    {
        selectBtn(1);
    }

    public void selectBtn3()
    {
        selectBtn(2);
    }

    public void selectBtn4()
    {
        selectBtn(3);
    }

    public void selectBtn5()
    {
        selectBtn(4);
    }
}
