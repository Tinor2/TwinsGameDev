using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Methods")]
    [SerializeField] private Transform attackTransform;
    
    [SerializeField] private LayerMask attackable;
    [Range(0f,200f)]
    [SerializeField] private float playerDamage = 1f;
    [Range(0f,20f)]
    [SerializeField] private float attackRange = 1.5f;

    [Header("Input")]
    [SerializeField] private UserInput userInput;
    [SerializeField] private GameObject inputManager;


    [SerializeField] private bool isAttack;

    private RaycastHit2D[] hits;
    private void Test(){
        Debug.Log("Still Running");
        
    }
    void Start()
    {
        userInput = inputManager.GetComponent<UserInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(userInput.controls.Attack.Attack.WasPressedThisFrame()){
            isAttack = true;
            Attack();
        }
        isAttack = false;
    }
    private void Attack(){
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackable);
        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();
            IDamageable enemyHealth = hits[i].collider.gameObject.GetComponent<EnemyHealth>();
            if(iDamageable != null){
                iDamageable.Damage(playerDamage);
                
            }
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
    
}
