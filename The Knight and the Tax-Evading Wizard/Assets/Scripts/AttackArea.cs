using UnityEngine;

//This script manages the collsion detection created by Knight's sword

public class AttackArea : MonoBehaviour
{
    public int damage;
    public float r;
    public Transform attackPoint;
    private bool CheckDone;
    // [SerializeField] GameObject player;
    [SerializeField] LayerMask enemies;
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] Collider2D[] enemiesHit;
    

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, r);
    }
    void Start(){
        // PlayerCombat playerCombat = player.GetComponent<PlayerCombat>();
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
    
        
}
