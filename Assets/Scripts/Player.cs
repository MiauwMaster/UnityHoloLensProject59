using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health;
    public int money;
	// Use this for initialization
	
    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void LoseLife(int life)
    {
        health -= life;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("DOOD");
    }
}
