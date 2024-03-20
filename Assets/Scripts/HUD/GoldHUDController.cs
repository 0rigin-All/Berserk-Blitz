using UnityEngine;
using UnityEngine.UI;

public class GoldHUDController : MonoBehaviour
{
     private Text goldText; // Déclarer la variable goldText comme privée

    // Méthode appelée au démarrage du jeu
    void Start()
    {
        // Trouver et initialiser le composant Text dans l'enfant de cet objet
        goldText = GetComponentInChildren<Text>();
        if (goldText == null)
        {
            Debug.LogError("Le composant Text n'a pas été trouvé dans l'enfant de cet objet.");
        }
    }
    // Mettre à jour le texte du HUD avec le nombre de pièces
      // Méthode pour mettre à jour le texte du HUD avec le nombre de pièces
    public void UpdateGoldText(int goldNumber)
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + goldNumber.ToString(); // Mettre à jour le texte avec le nombre de pièces
        }
        else
        {
            Debug.LogError("La référence au composant Text est null.");
        }
    }
}
