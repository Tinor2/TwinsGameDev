<<<<<<< HEAD
=======

using Unity.VisualScripting;
using UnityEditor.Rendering;
>>>>>>> parent of e76f36d (Started fixing kinghts attackarea)
using UnityEngine;

//This script manages the collsion detection created by Knight's sword

public class AttackArea : MonoBehaviour
{
    public int damage;
    public float r;
    [SerializeField] GameObject player;
    [SerializeField] LayerMask enemies;
    [SerializeField] PlayerCombat playerCombat;
    
<<<<<<< HEAD

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, r);
    }
    void Start(){
        // PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
        if(gameObject.tag == "Bullet"){attackPoint = transform;}
        
    }
    void Update()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(gameObject.transform.position, r,enemies);
        if (enemiesHit == null) return;               
        foreach(Collider2D enemy in enemiesHit){
            //Store that script into a variable
            Health health = enemy.gameObject.GetComponent<Health>();
            //Deal damage to the specific health script
            health.Damage(damage);
            Debug.Log(damage.ToString());
            //If this script is on a bullet then
            if (gameObject.tag == "Bullet") {
            //Disable the bullet
                gameObject.SetActive(false);
            }
            }

    }      
    
=======
    void Start(){
        PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
    }
    void Update()
    {
        Debug.Log("Enabled");
        //Store all enemies hit in a list
        if (playerCombat.attacking){
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), r,enemies);
            if(enemiesHit != null){ 
                for (int i = 0; i < enemiesHit.Length; i++){
                    if(i>1) enemiesHit[i-1] = null;
                    //Store that script into a variable
                    Health health = enemiesHit[1].GetComponent<Health>();
                    //Deal damage to the specific health script
                    health.Damage(damage);
                    Debug.Log(damage.ToString());
                    //If this script is on a bullet then
                    if (gameObject.tag == "Bullet") {
                        //Disable the bullet
                        gameObject.SetActive(false);
                    }
                }
            }
        }
>>>>>>> parent of e76f36d (Started fixing kinghts attackarea)
        
       
    }
}
