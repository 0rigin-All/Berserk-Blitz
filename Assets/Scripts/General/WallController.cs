using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    public int wall_health = 50;
    int inflictedDamage;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimeDamage", 1F, 1F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TimeDamage(){
        inflictedDamage = 1;
        Damage(inflictedDamage);
    }

    void OnCollisionStay(Collision collideEvent){

        var element = collideEvent.gameObject;

        if (element.tag == "Enemy"){
            if (element.name.Contains("StrongerEnemy")){
                inflictedDamage = 10;
                Damage(inflictedDamage);
            }else{
                inflictedDamage = 1;
                Damage(inflictedDamage);
            }
        }

    }

    void Damage(int inflictedDamage)
    {
        wall_health = wall_health - inflictedDamage;
        if (wall_health <= 0){
            Destroy(gameObject);
        }
    }

}
