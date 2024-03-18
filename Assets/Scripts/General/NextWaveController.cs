using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWaveController : MonoBehaviour
{

    private bool waveState;
    private GameObject canva;

    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        canva = GameObject.Find("Canvas");
        waveState = canva.GetComponent<WaveScript>().finishedWave;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave(){
        waveState = canva.GetComponent<WaveScript>().finishedWave = false;
        Time.timeScale = 1F;
    }
}
