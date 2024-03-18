using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        // Charge la scène appelée "Main"
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        // Quitte l'application
        Application.Quit();
    }
}