using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

//The heak=lth system for an enemy
public class Health : MonoBehaviour
{
    public int defhealth;
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
    public void EnRespawn() {
        health = defhealth;
        transform.position = DefaultRespawn;
    }
    void Update()
    {
        if (Respawn == true)
        {
            EnRespawn();
            Respawn = false;
        }
    }


}
