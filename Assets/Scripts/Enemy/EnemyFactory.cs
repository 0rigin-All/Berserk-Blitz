using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject strongerEnemyPrefab;
    public GameObject sol;
    private GameObject player;
    private Bounds bounds;
    private GameObject canva;
    private bool waveState;
    Vector3 enemyPosition;

    // Ancienne méthode pour instancier à intervale régulier
    //private float nextCar = 2F;
    //private float carRate = 2F;


    // Start is called before the first frame update
    void Start()
    {
        canva = GameObject.Find("Canvas");
        bounds = sol.GetComponent<Renderer>().bounds;
        enemyPosition = new Vector3();

        
        InvokeRepeating("CreaEnemy", 2.0f, 2.5f);
        
        // Récupère l'état des vagues toutes les secondes
        InvokeRepeating("GetWaveState", 1F, 1F);

    }

    // Update is called once per frame
    void Update()
    {
        // Récupère le script du Canva qui influe directement sur les vagues
        waveState = canva.GetComponent<WaveScript>().finishedWave;
    }


    void CreaEnemy()
    {

        // Vérifie si la vague est terminée ou non avec le WaveState
        if (waveState == false)
        {
            RandomCo();
            // enemyPrefab.GetComponent<NavMeshScript>().[...] => Permet de récupérer l'attribut donné dans les [...] et de le redéfinir.
            // GameObject.Find("Player") => Permet de trouver l'object Player dans la scene.
            player = GameObject.Find("Player");

            var listEnemy = GameObject.Find("Enemy");

            enemyPrefab.GetComponent<NavMeshScript>().targetObject = player;
            strongerEnemyPrefab.GetComponent<NavMeshScript>().targetObject = player;
            if (player)
            {
                if (listEnemy.transform.childCount < 10)
                {
                    // Paramètres du Weak Enemy
                    GameObject weakEnemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity, listEnemy.transform);
                    EnemyController weakEnemyController = weakEnemy.GetComponent<EnemyController>();
                    weakEnemyController.SetEnemyProperties(50, 1, 2, 120, 8);

                    // Paramètres du Stronger Enemy
                    GameObject strongerEnemy = Instantiate(strongerEnemyPrefab, enemyPosition, Quaternion.identity, listEnemy.transform);
                    EnemyController strongerController = strongerEnemy.GetComponent<EnemyController>();
                    strongerController.SetEnemyProperties(100, 15, 4, 120, 15);
                }
            }
        }else{
            //Faire un truc quand la vague est terminée
        }


    }


    void RandomCo()
    {
        enemyPosition.x = Random.Range(bounds.min.x, bounds.max.x);
        //Debug.Log(enemyPosition.x);
        enemyPosition.y = enemyPrefab.GetComponent<Renderer>().bounds.size.y / 2;
        enemyPosition.z = Random.Range(bounds.min.z, bounds.max.z) / 2;
    }

    void GetWaveState(){
        waveState = canva.GetComponent<WaveScript>().finishedWave;
    }
}