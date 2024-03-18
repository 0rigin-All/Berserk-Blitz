using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float range = 5F;
    private float power;
    private Rigidbody bulletRigidbody;

    private float speed;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        // Assurez-vous que la balle part en ligne droite
        bulletRigidbody.velocity = transform.forward * speed;
        Invoke("DestroyBullet", range);


    }

    public void SetBulletProperties(float range, float power, float speed)
    {
        this.range = range;
        this.power = power;
        this.speed = speed;
    }
    public float getPower()
    {
        return power;
    }
    void OnCollisionEnter(Collision collision)
    {

        var element = collision.gameObject;

        if (element.CompareTag("Enemy"))
        {
            // Si la collision se produit avec un objet ayant le tag "Enemy"
            Destroy(gameObject);  // Détruire la balle
        }
    }
    void DestroyBullet()
    {
        // Fonction appelée pour détruire la balle après le délai spécifié dans range
        Destroy(gameObject);
    }
    // Ajoutez d'autres logiques nécessaires pour le comportement de la balle ici
}
