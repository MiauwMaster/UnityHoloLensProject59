using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float health;
    public bool isDead = false;
    public int moneyAmount;
    public int damage;
	public GameObject deathParticle;


    public void Update()
    {
        if(!Camera.main.GetComponent<Player>().isAlive)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// flag enemy as dead, add money to the player, play the death sound and destroy the gameobject
    /// </summary>
    public void Die ()
    {
        isDead = true;
        Camera.main.GetComponent<Player>().AddMoney(moneyAmount);
		FindObjectOfType<SoundManager>().Play("DeathSound");
        Destroy(gameObject);
    }

    /// <summary>
    /// Deal gunDamage to the enemy
    /// </summary>
    /// <param name="life">the amount of gunDamage this enemy takes</param>
    public void LoseLife(float life)
    {
        health -= life;

        if (isDead)
        {
            return;
        }
        
        if (health <= 0)
        {
			GameObject effectins = (GameObject)Instantiate(deathParticle, this.transform.position, this.transform.rotation);
			Destroy(effectins, 2.0f);
			Die();
        }
    }

    
    }
