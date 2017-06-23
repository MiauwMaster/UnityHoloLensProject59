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

    /// <summary>
    /// Add money to the player
    /// </summary>
    /// <param name="amount">amount of money</param>
    public void AddMoney(int amount)
    {
        money += amount;
    }
    /// <summary>
    /// Remove money from the player
    /// </summary>
    /// <param name="amount">amount of money</param>
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

    /// <summary>
    /// Lower the life (hp) of the player
    /// </summary>
    /// <param name="life">anount of lives to remove</param>
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

    /// <summary>
    /// Death of the player
    /// </summary>
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
