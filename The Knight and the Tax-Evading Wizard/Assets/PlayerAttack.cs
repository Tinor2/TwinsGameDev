using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [Header("Attack Timing")]
    [SerializeField] private float cooldownAttack = 0.15f;
    public int attackLength {get; private set; } = 2; //can be seen from other scripts, not changed, get is assumed true
    public bool isDamaging {get; private set; } = false; 
    private float attackTimeCount;
    private int frameCount;

    [SerializeField] private bool isAttack;

    private RaycastHit2D[] hits;

    void Start()
    {

        userInput = inputManager.GetComponent<UserInput>();
    }
    void Update()
    {
        if(userInput.controls.Attack.Attack.WasPressedThisFrame() && attackTimeCount >= cooldownAttack){
            attackTimeCount = 0f;
            isAttack = true;
            Attack();
        }
        isAttack = false;
        attackTimeCount += Time.deltaTime;
    }
    private void Attack(){
        //Store all enemies in certain range into a list
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackable);
        //Cycle through and apply damage to said enemies
        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();
            if(iDamageable != null){
                iDamageable.Damage(playerDamage);
                
            }
        }
    }
    public IEnumerator attackWhenReady(){
        isDamaging = true;
        while(isDamaging){ //Contents will run for as many frames as the condition is met
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackable);
            //Cycle through and apply damage to said enemies
            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();
                if(iDamageable != null){
                    iDamageable.Damage(playerDamage);
                    
                }
            }
            frameCount ++;
            if (frameCount >= attackLength)
            {
                isDamaging = false;
            }
            yield return null; //wait 1 more frame

        }
    }
    private void OnDrawGizmosSelected(){
            Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
    

