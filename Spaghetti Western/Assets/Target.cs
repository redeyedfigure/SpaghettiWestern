using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    void Start(){
        currentHealth = maxHealth;
    }
    public void Hit(float damage){
        currentHealth = currentHealth - damage;
        if(currentHealth <= 0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
