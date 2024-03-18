using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class WallHUDController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private TextMeshProUGUI wall_Text;  

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
            wall_Text = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Mise à jour de la valeur wall à chaque frame
        int wall = playerController.wallNumber;

        if (wall <= 0)
        {
            wall_Text.text = "Plus de murs";
        }
        else
        {
            // Mise à jour du texte avec la valeur de la santé
            wall_Text.text = "Murs: " + wall.ToString();
        }

    }
}

