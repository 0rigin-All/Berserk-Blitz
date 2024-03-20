// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Users;

// public class PlayerController : MonoBehaviour
// {
//     public int health = 100;

//     public GameObject wallPrefab;

//     public int wallNumber = 1;

//     private GameObject canva;
//     private bool waveState;

//      private PlayerInput playerInput;

//     // Start is called before the first frame update
//     void Start()
//     {
//         canva = GameObject.Find("Canvas");
//         playerInput = GetComponent<PlayerInput>();
//         InvokeRepeating("WaveStateCheck", 0.5F, 0.5F);
//     }

//     // Update is called once per frame
//     void Update()
//     {   
//     }

//     void OnPlaceWall(InputValue value)
//     {
//         Debug.Log("OnPlaceWall Action is called");
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit))
//         {
//             Debug.LogWarning(hit.distance);
//             Debug.Log(wallNumber);
//             if (wallNumber >= 1)
//             {

//                 wallNumber = wallNumber - 1;

//                 if (hit.distance < 8)
//                 {
//                     // Récupère l'angle de rotation du joueur (et donc l'angle de vision)
//                     var angle = gameObject.transform.localEulerAngles.y;

//                     // Créé un Quaternion avec une rotation en y équivalante à l'angle du joueur donc les murs font toujours face au joueur
//                     Quaternion rotation = Quaternion.Euler(0, angle, 0);

//                     Vector3 wallPosition = new Vector3(hit.point.x, 1.25F, hit.point.z);

//                     // Instantiate the wallPrefab at the hit point
//                     Instantiate(wallPrefab, wallPosition, rotation);

//                 }
//             }
//         }
//     }

//     void WaveStateCheck(){
//         waveState = canva.GetComponent<WaveScript>().finishedWave;

//         if (waveState == false){
//             gameObject.SetActive(true);
//             InputUser inputUser = playerInput.user;
//             InputUser.PerformPairingWithDevice(PlayerInput.devices, inputUser);
//         }else{
//             playerInput.ActivateInput();
//         }
//     }

// }


using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public GameObject wallPrefab;
    public int wallNumber = 1;
    public int goldNumber = 0;
    private GameObject canva;
    private bool waveState;
    private PlayerInput playerInput;
    public GoldHUDController GoldhudController;

    void Start()
    {
        canva = GameObject.Find("Canvas");
        playerInput = GetComponent<PlayerInput>();
        InvokeRepeating("WaveStateCheck", 0.5F, 0.5F);
    }

    void OnPlaceWall(InputValue value)
    {
        Debug.Log("OnPlaceWall Action is called");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.LogWarning(hit.distance);
            Debug.Log(wallNumber);
            if (wallNumber >= 1)
            {

                wallNumber = wallNumber - 1;

                if (hit.distance < 8)
                {
                    // Récupère l'angle de rotation du joueur (et donc l'angle de vision)
                    var angle = gameObject.transform.localEulerAngles.y;

                    // Créé un Quaternion avec une rotation en y équivalante à l'angle du joueur donc les murs font toujours face au joueur
                    Quaternion rotation = Quaternion.Euler(0, angle, 0);

                    Vector3 wallPosition = new Vector3(hit.point.x, 1.25F, hit.point.z);

                    // Instantiate the wallPrefab at the hit point
                    Instantiate(wallPrefab, wallPosition, rotation);

                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggerenter");
        if (other.CompareTag("Gold"))
        {
            goldNumber++; // Augmentez le nombre d'or du joueur
            Destroy(other.gameObject); // Détruisez la pièce
             UpdateGoldHUD();
        }
    }
    void UpdateGoldHUD()
    {
                Debug.Log("normalement le hud se met à jour");
        if (GoldhudController != null)
        {        Debug.Log("normalement le hud se met à jour et on rentre dans le if");
            GoldhudController.UpdateGoldText(goldNumber); // Mettre à jour le HUD avec le nouveau nombre de pièces
        }
    }
    void WaveStateCheck()
    {
        waveState = canva.GetComponent<WaveScript>().finishedWave;

        if (waveState == false)
        {
            gameObject.SetActive(true);
        }
    }
}
