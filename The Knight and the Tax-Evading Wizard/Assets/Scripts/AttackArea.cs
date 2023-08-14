
using UnityEngine;

//This script manages the collsion detection created by Knight's sword

public class AttackArea : MonoBehaviour
{
    //Damage output of player's sword attacl
    public int damage;
    //On Collision
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //If the other collider gameObject has the health script then
       if(collider.GetComponent<Health>() != null)
        { 
            //Store that script into a variable
            Health health = collider.GetComponent<Health>();
            //Deal damage to the specific health script
            health.Damage(damage);
            //If this script is on a bullet then
            if (gameObject.tag == "Bullet") {
                //Disable the bullet
                gameObject.SetActive(false);
            }
            
       }
    }
}
