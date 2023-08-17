using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

//The heak=lth system for an enemy
public class Health : MonoBehaviour
{
    public int defHealth;
    [SerializeField] float health;

    public Vector3 dummyKnock;

    private Vector3 Banished;
    [SerializeField] Vector3 DefaultRespawn;

    [SerializeField] Rigidbody2D rb;
    
    [SerializeField] GameObject PlayerInfo;
    private PlayerConstants playerConstants;

    [SerializeField] bool Respawn;

    public float oldHealth;

    void Start (){
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerConstants= PlayerInfo.GetComponent<PlayerConstants>();
        health = defHealth;
    }
    public void Damage(float damage) {
        oldHealth = health;
        health -= damage;
        if (playerConstants.pC_PlayerFlip) rb.AddForce(new Vector3(-dummyKnock.x, dummyKnock.y, 0));
        else rb.AddForce(dummyKnock);

        if (health <= 0)
        {
            gameObject.SetActive(false); 
            transform.position = Banished;
        }
    }
    public void enemyRespawn() {
        health = defHealth;
        transform.position = DefaultRespawn;
    }
    void Update()
    {
        if (Respawn == true)
        {
            enemyRespawn();
            Respawn = false;
        }
    }


}
