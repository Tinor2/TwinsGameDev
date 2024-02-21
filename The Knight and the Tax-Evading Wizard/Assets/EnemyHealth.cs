using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth;
    [SerializeField] private float currentHealth;
    
    void Start()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
    }
    public void Damage(float damageAmount){
        currentHealth -= damageAmount;
        if(currentHealth <= 0){
            currentHealth = 0f;
            Die(true);
        }
    }
    public void Die(bool isDead){
        gameObject.SetActive(!isDead);
    }
}
