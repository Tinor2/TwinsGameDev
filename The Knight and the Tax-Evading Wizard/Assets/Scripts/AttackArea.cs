using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
//This script manages the collsion detection created by Knight's sword

public class AttackArea : MonoBehaviour
{
    public int damage;
    public float r;
    public Transform attackPoint;
    [SerializeField] GameObject player;
    [SerializeField] LayerMask enemies;
    [SerializeField] PlayerCombat playerCombat;
    public Collider2D[] enemiesHit;
    private Collider2D[] blank;
    
    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, r);
    }
    void Start(){
        playerCombat = player.GetComponent<PlayerCombat>();
        if(gameObject.CompareTag("Bullet")) {attackPoint = transform;}

        
    }
    void Update()
    {
        
        if (playerCombat.attacking){
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(gameObject.transform.position, r,enemies);
            if (enemiesHit == blank){goto EndAttackSeq;}
            List<Collider2D> uniqueEnemies = enemiesHit.Distinct().ToList();
            Debug.Log(uniqueEnemies);
            foreach(Collider2D enemy in uniqueEnemies){
                //Store that script into a variable
                Health health = enemy.gameObject.GetComponent<Health>();
                //Deal damage to the specific health script
                health.Damage(damage);   
                Debug.Log(damage.ToString());
                //If this script is on a bullet then
                if (gameObject.CompareTag("Bullet")) {
                //Disable the bullet
                gameObject.SetActive(false);
                }
                goto EndAttackSeq;
            }
             
        }     
        EndAttackSeq:
                playerCombat.attacking = false;    
    }
}
