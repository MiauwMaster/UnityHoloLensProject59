using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{

    public Transform target;
    public float speed;

    void Start()
    {
        //target = Camera.main.transform;
        target = GameObject.FindWithTag("target").transform;
    }

    void Update()
    {
        //If the enemy has a target
        if (target != null)
        {
            //Move towards the position of the player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            //If enemy reaches the player
            if (transform.position == target.position)
            {
                //Lose player life by the amount of gunDamage the enemy does. 
                Camera.main.GetComponent<Player>().LoseLife(GetComponent<Enemy>().damage);
				//Destroy the enemy
				Destroy(gameObject);
            }

        }
    }
}

