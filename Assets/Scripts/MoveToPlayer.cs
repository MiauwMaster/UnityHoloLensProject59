using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {

    public Transform target;
    public float speed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target").transform;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (transform.position == target.position)
        {
            //TODO: player lose life
            Destroy(gameObject);
        }
    }
}
