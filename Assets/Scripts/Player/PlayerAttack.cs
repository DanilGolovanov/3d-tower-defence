using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Managers;
using TowerDefence.Enemies;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    Camera mainCam;
    private GameObject crosshair;


    void Awake()
    {

        weaponManager = GetComponent<WeaponManager>();;

        crosshair = GameObject.FindWithTag(Tags.CROSSHAIR);

        mainCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // handle melee
            if (weaponManager.GetCurrentSelectedWeapon().tag == Tags.MELEE_TAG)
            {
                //weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
            }
            // handle shoot
            if (weaponManager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
            {
                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                BulletFired();
            }
        }

    }
    public void BulletFired()
    {

        RaycastHit hit;
        Debug.Log("Bullet Fired");

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<Enemy>().Damage(damage);
            }
            else
            {
                Debug.Log("Missed");
            }

        }

    }
}


































