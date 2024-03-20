using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    int player_health;
    private float nextInvicibilityTime;
    private float invincibilityDuration = 0.5F;
    private bool invincibility = false;
    public float health;
    public int damage;
    private float speed;
    private float angularSpeed;
    private float acceleration;

    public GameObject dropPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Cherche le gameobjet avec le tag Player et le stocke dans player
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Récupère le script contenu dans le player
            playerController = player.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning("Update " + playerController.invicibility.ToString() + " " + Time.time );
        if (invincibility && Time.time > nextInvicibilityTime)
        {
            Debug.LogError("Fin de l'invincibilité " + Time.time);
            invincibility = false;
        }
    }
     private void DropItem()
    {
         Debug.Log("drop gold !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if (dropPrefab != null)
        {
            // Instancier la pièce à l'emplacement de l'ennemi
            Debug.Log("gold drop !!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("object detruit");
        // Appeler la méthode pour générer la pièce
        DropItem();
    }
    void OnCollisionEnter(Collision collision)
    {
        var element = collision.gameObject;
        if (element.CompareTag("Bullet"))
        {
            int intBulletDamage = Mathf.FloorToInt(element.GetComponent<BulletController>().getPower());
            health -= intBulletDamage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }

    }
    // CollisionStay applique ce qui est dans la fonction tant que l'objet touche l'autre
    void OnCollisionStay(Collision collideEvent)
    {
        var element = collideEvent.gameObject;

        //Debug.LogWarning("Temps + Invincibilité " + Time.time + " "+  playerController.invicibility.ToString());
        if (element.CompareTag("Player") && playerController != null && invincibility != true)
        {
            // Player_health est mis à jour avec la valeur health du player
            player_health = playerController.health;
            player_health = player_health - damage;
              playerController.health = player_health;
        

        // Met à jour la valeur health dans le player avec notre variable player_health
        if (player_health <= 0)
        {
            invincibility = false;
            Destroy(element);
        }
        invincibility = true;

        nextInvicibilityTime = Time.time + invincibilityDuration;
        Debug.LogError("Tu es invincible jusqu'à " + nextInvicibilityTime);
    
    }
    }
    public void SetEnemyProperties(float health, int damage, float speed, float angularSpeed, float acceleration)
    {
        UnityEngine.AI.NavMeshAgent Compo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        Compo.speed = speed;
        this.angularSpeed = angularSpeed;
        Compo.angularSpeed = angularSpeed;
        this.acceleration = acceleration;
        Compo.acceleration = acceleration;
    }
}