
using UnityEngine;

//This script manages the collsion detection created by Knight's sword

public class AttackArea : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.GetComponent<Health>() != null)
        { 
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            if (gameObject.tag == "Bullet") {
                gameObject.SetActive(false);
            }
            
       }
    }
}
