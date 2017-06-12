using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public bool isDead = false;
    public int moneyAmount;
    public int damage;

    // Use this for initialization
  
    public void Die ()
    {
        isDead = true;
        Camera.main.GetComponent<Player>().AddMoney(moneyAmount);
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
