using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public Transform head;  // Référence à la tête de la tourelle
    public Transform bulletSpawnPoint;  // Référence au point de spawn des balles
    public GameObject bulletPrefab;  // Préfab de la balle
    public float rotationSpeed = 5f;  // Vitesse de rotation de la tête
    public float fireRate = 1f;  // Cadence de tir en secondes
    public float bulletRange = 10f;  // Portée de la balle
    public float bulletPower = 10f;  // Puissance de la balle

    public float bulletSpeed = 100F;

    private float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time;  // Initialiser le temps de tir
    }

    void Update()
    {
        RotateTurretHead();
        TryShoot();
    }

    void RotateTurretHead()
    {
        // Trouver l'ennemi le plus proche
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            // Calculer la direction vers l'ennemi
            Vector3 targetDirection = nearestEnemy.transform.position - head.position;

            // Calculer la rotation vers la direction ciblée
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Effectuer une interpolation slerp pour une rotation fluide
            head.rotation = Quaternion.Slerp(head.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void TryShoot()
    {
        // Vérifier si le temps est venu de tirer
        if (Time.time >= nextFireTime)
        {
            // Tirer une balle avec portée et puissance définies
            ShootBullet();

            // Mettre à jour le temps du prochain tir
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletController bulletController = bullet.GetComponent<BulletController>();

        if (bulletController != null)
        {
            // Définir les propriétés de la balle
            bulletController.SetBulletProperties(bulletRange, bulletPower, bulletSpeed);

            // Orienter la balle dans la direction de la tête
            bullet.transform.forward = head.forward;
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
            return null;

        GameObject nearestEnemy = enemies[0];
        float nearestDistance = Vector3.Distance(head.position, nearestEnemy.transform.position);

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(head.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }
}