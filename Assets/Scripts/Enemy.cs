using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public bool isDead = false;

    // Use this for initialization
  
    void Die ()
    {
        isDead = true;
        Destroy(gameObject);
    }

    public void LoseLife(int life)
    {
        health -= life;

        if (isDead)
        {
            return;
        }
        

        if (health <= 0)
        {
            Die();
        }
    }

    
    }
