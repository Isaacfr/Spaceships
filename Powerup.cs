﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if(transform.position.y < -2.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            if(player != null)
            {
                player.TripleShotActive();
            }

            Destroy(this.gameObject);
        }
    }
}
