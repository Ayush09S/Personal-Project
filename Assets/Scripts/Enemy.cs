using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float maxDistFromPlayer = .03f;
    public float health = 100f;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxDistFromPlayer);

        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
