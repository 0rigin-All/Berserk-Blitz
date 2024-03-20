using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerHUDController : MonoBehaviour
{
    public float waveTime;
    private GameObject canva;
    private int seconde;

    public Boolean isPaused;

    GameObject nextWaveButton;
    GameObject temps_restant;
    GameObject pauseButton;
    GameObject continueButton;
    TextMeshProUGUI timer_Text;

    // Start is called before the first frame update
    void Start()
    {
        canva = GameObject.Find("Canvas");
        temps_restant = GameObject.Find("Canvas/WaveTimer");
        waveTime = canva.GetComponent<WaveScript>().timer;
        timer_Text = temps_restant.GetComponent<TextMeshProUGUI>();


        // Récupère le bouton de vague suivante et le cache
        nextWaveButton = GameObject.Find("Canvas/NextWaveButton");
        pauseButton = GameObject.Find("Canvas/PauseMenu");
        continueButton = GameObject.Find("Canvas/PauseMenu/Continuer");
        nextWaveButton.SetActive(false);
        pauseButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Pause " + isPaused);
        // Récupère le temps 
        waveTime = canva.GetComponent<WaveScript>().timer;
        seconde = Mathf.FloorToInt(waveTime);

        if (seconde <= 0 || Time.timeScale == 0F && isPaused == false)
        {
            timer_Text.text = "Vague terminée";

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            nextWaveButton.SetActive(true);
        }
        else
        {
            timer_Text.text = "Temps restant: " + seconde + " s";
            nextWaveButton.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnPauseMenu(InputValue value)
    {
        if (isPaused == true)
        {
            // Quand le jeu est plus en pause
            isPaused = false;

            pauseButton.SetActive(false);

            Time.timeScale = 1F;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Quand le jeu est en pause 
            isPaused = true;
            Time.timeScale = 0F;

            pauseButton.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

    }

}