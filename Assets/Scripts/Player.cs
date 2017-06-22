using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 5;
    public int money = 15;
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
        if (amount > money)
        {
            return;
        }

        money -= amount;

        if (money < 0)
        {
            money = 0;
        }
    }

    public void LoseLife(int life)
    {
        health -= life;
		FindObjectOfType<SoundManager>().Play("HitSound");

		if (health <= 0 && isAlive)
        {
            Die();
        }

        if (health < 0)
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
        moneyText.text = money.ToString();
        livesText.text = health.ToString() + " / 5";
    }
}
