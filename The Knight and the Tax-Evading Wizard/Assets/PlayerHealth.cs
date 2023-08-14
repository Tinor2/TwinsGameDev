using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{
    public float playerHealth;
    private bool takeDamage; //filler
    private float damage; //filler    
    void Update(){
        if (takeDamage) {//filler
            playerHealth -= damage;
            if (playerHealth <= 0){
                Debug.Log("restart");
            }
        }
    }
}
