using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveScript : MonoBehaviour
{

    private IEnumerator coroutine;
    public float timer;
    public float waveTime;
    public bool finishedWave = false;

    
    // Start is called before the first frame update
    void Start()
    {

        waveTime = 10F;

        timer = waveTime;

        // Temps avant que la vague se termine 
        coroutine = WaveTimer(waveTime);
        // Obligatoire pour commencer des coroutines (Actions faites avec de la latence)
        StartCoroutine(coroutine);

    }

    // Update is called once per frame
    void Update()
    {
        if(finishedWave == false ){
            timer -= Time.deltaTime;
        }else{
            timer = waveTime ;
            coroutine = WaveTimer(timer);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator WaveTimer(float waveTime)
    {
        yield return new WaitForSeconds(waveTime);

        // Cherche tous les GameObject avec le Tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Destruction de tous les ennemis
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }

        Time.timeScale = 0F;
        finishedWave = true;
    }
}
