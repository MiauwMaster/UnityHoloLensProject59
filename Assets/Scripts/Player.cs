using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int health;
    public int money;
    public bool isAlive = true;
    public Text moneyText;
    public Text livesText;

	// Use this for initialization
	
    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void LoseMoney(int amount)
    {
        money -= amount;

        if (money < 0)
        {
            money = 0;
        }
    }

    public void LoseLife(int life)
    {
        health -= life;

        if (health <= 0 && isAlive)
        {
            Die();
        }

        if(health < 0)
        {
            health = 0;
        }
    }
    void Die()
    {
        isAlive = false;
        Debug.Log("DOOD");
    }

    void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        livesText.text = "Health: " + health.ToString();
    }
}
