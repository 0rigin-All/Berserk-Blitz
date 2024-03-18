using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshScript : MonoBehaviour
{
    public GameObject targetObject;
    UnityEngine.AI.NavMeshAgent myNavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            // Tous les NavMeshAgent suivent le targetobject (le joueur)
            myNavMeshAgent.SetDestination(targetObject.transform.position);
        }
        else
        {
            // Cherche tous les GameObject avec le Tag "Enemy"
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Destruction de tous les ennemis
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }
}