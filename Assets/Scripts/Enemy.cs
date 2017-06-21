using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float health;
    public bool isDead = false;
    public int moneyAmount;
    public int damage;
	public GameObject deathParticle;

    // Use this for initialization

    public void Update()
    {
        if(!Camera.main.GetComponent<Player>().isAlive)
        {
            Destroy(gameObject);
        }
    }

    public void Die ()
    {
        isDead = true;
        Camera.main.GetComponent<Player>().AddMoney(moneyAmount);
        Destroy(gameObject);
    }

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
