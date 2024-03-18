// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class GunController : MonoBehaviour
// {
//     public GameObject bulletPrefab;
//     public Transform bulletSpawnPoint;

//     public float fireRate = 0.5f;  // Cadence de tir en secondes
//     public float bulletRange = 5f;  // Temps en secondes avant que la balle disparaisse
//     public float bulletPower = 10f;  // Puissance de la balle

//     private float nextFireTime;
//     private bool shooting;

//     void Start()
//     {
//         nextFireTime = Time.time;  // Initialiser le temps de tir
//     }

//     void Update()
//     {
//         if (shooting && Time.time >= nextFireTime)
//         {
//             Debug.Log("OnShoot Action is called");
//             ShootBullet();
//             nextFireTime = Time.time + 1f / fireRate;  // Mettre à jour le temps du prochain tir
//         }
//     }

//     void OnShoot(InputValue value)
//     {
//         shooting = value.isPressed;
//     }

//     void ShootBullet()
//     {
//         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//         BulletController bulletController = bullet.GetComponent<BulletController>();

//         if (bulletController != null)
//         {
//             bulletController.SetBulletProperties(bulletRange, bulletPower);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float fireRate = 0.5f;  // Cadence de tir en secondes
    public float bulletRange = 5f;  // Temps en secondes avant que la balle disparaisse
    public float bulletPower = 10f;  // Puissance de la balle

    public float bulletSpeed = 25F;

    private float nextFireTime;
     private bool shooting;

    void Start()
    {
        nextFireTime = Time.time;  // Initialiser le temps de tir
    }

    void Update()
    {
        // Vous pouvez ajouter d'autres logiques de mise à jour ici si nécessaire
        UpdateGunRotation();

          if (shooting && Time.time >= nextFireTime)
        {
            Debug.Log("OnShoot Action is called");
            ShootBullet();
            nextFireTime = Time.time + 1f / fireRate;  // Mettre à jour le temps du prochain tir
        }
    }

    void OnShoot(InputValue value)
    {
         shooting = value.isPressed;
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletController bulletController = bullet.GetComponent<BulletController>();

        if (bulletController != null)
        {
            bulletController.SetBulletProperties(bulletRange, bulletPower, bulletSpeed);

            // Orienter la balle dans la direction de la caméra
            bullet.transform.forward = Camera.main.transform.forward;
        }
    }

    void UpdateGunRotation()
    {
        // Orienter l'arme dans la direction de la caméra
        transform.forward = Camera.main.transform.forward;
         transform.Rotate(90f, 0f, 0f);  // Ajout de la rotation de 90 degrés sur l'axe X

    }
}