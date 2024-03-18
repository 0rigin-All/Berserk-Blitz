using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimerHUDController : MonoBehaviour
{
    public float waveTime;
    private GameObject canva;
    private GameObject player;
    private int seconde;
    public FirstPersonController firstPersonController;

    private PlayerInput playerInput;


    //private NextWaveController nextWaveController;
    GameObject nextWaveButton;
    TextMeshProUGUI timer_Text;

    // Start is called before the first frame update
    void Start()
    {
        canva = GameObject.Find("Canvas");
        player = GameObject.Find("Player");
        waveTime = canva.GetComponent<WaveScript>().timer;
        timer_Text = GetComponent<TextMeshProUGUI>();

        // nextWaveController = canva.GetComponent<NextWaveController>();
        // Récupère le bouton de vague suivante et le cache
        nextWaveButton = GameObject.Find("Canvas/NextWaveButton");
        nextWaveButton.SetActive(false);

        playerInput = player.GetComponent<PlayerInput>();

        firstPersonController = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        // Accédez au temps écoulé depuis le script WaveScript
        waveTime = canva.GetComponent<WaveScript>().timer;
        seconde = Mathf.FloorToInt(waveTime);

        if (seconde <= 0 || Time.timeScale == 0F)
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
        Debug.Log("OnPauseMenu Action is called");
        Time.timeScale = 0F;
    }

}