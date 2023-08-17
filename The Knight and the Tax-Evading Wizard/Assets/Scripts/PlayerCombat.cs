using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    public GameObject attackArea = default;
    public GameObject FirePoint;
    public GameObject ObjectPool;
    [SerializeField] GameObject WizardBullet;

    public bool attacking = false;
    [SerializeField] float timeToAttack = 0.5f;
    private float timer = 0f;

    public bool attackReady;
    [SerializeField] float cooldown = 0.3f;
    private float timer2 = 0f;

    public Charactar charactar;
    public ObjectPooling objectPooling;
    public AttackArea attackAreaSc;

    public GameObject gameobj;

    public int indexList;

    void Start()
    {
        //Setting the sword's attack area as the first child of the player
        attackArea = transform.GetChild(0).gameObject;  
        // This is the charactar, checks whether active player is wizard or knight
        Charactar charactar = gameObject.GetComponent<Charactar>();
        ObjectPooling objectPooling = ObjectPool.GetComponent<ObjectPooling>();  
        AttackArea attackAreaSc = attackArea.GetComponent<AttackArea>(); 
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            if (attackReady)
            {
                // insert animation
                Attack();
            }

        }
        if (attacking) {
            timer += Time.deltaTime;
            if (timer >= timeToAttack){
                attacking = false;
                attackArea.SetActive(attacking);
                timer = 0f;
                attackReady = false;
            }
        }
        
        if (!attackReady){
            timer2 += Time.deltaTime;
            if (timer2 >= cooldown)
            {
                attackReady = true;
                timer2 = 0f;
            }
        }

       
    }
    private void Attack(){
        if (attackReady){
            attacking = true;
            if (charactar.character){
                attackArea.SetActive(attacking);
            }
            else{
                GameObject bullet= objectPooling.GetObjectFromPool();
                if (bullet != null){
                    bullet.transform.position = FirePoint.transform.position;
                }
            }

        }
        
    }
}