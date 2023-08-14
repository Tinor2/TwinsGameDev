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

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>() != null){}
    }
}
