using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    Camera mainCam;
    private GameObject crosshair;


    void Awake()
    {

        weapon_Manager = GetComponent<WeaponManager>();;

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
            if (weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.MELEE_TAG)
            {
                //weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
            }
            // handle shoot
            if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
            {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
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
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
            else
            {
                Debug.Log("Missed");
            }

        }

    }
}


































