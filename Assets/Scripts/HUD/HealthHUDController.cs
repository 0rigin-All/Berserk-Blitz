using System.Collections;
using System.Collections.Generic;
using TMPro;  // Importez le namespace TextMeshPro
using UnityEngine;

public class HealthHUDController : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    TextMeshProUGUI health_Text;  // Utilisez TextMeshProUGUI au lieu de Text

    // Start is called before the first frame update
    void Start()
    {
        // Cherche le gameobjet avec le tag Player et le stocke dans player
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Récupère le script contenu dans le player
            playerController = player.GetComponent<PlayerController>();

            // Récupère les textes TextMeshPro UI (NE PAS FAIRE GetComponent<Text> SINON CA TROUVE PAS)
            health_Text = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Mise à jour de la valeur health à chaque frame
        int health = playerController.health;

        if (health <= 0)
        {
            health_Text.text = "Vous êtes mort";
        }
        else
        {
            // Mise à jour du texte avec la valeur de la santé
            health_Text.text = "Health: " + health.ToString();
        }

    }
}

