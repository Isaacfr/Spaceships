﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if(transform.position.y < -2.5f)
        {
            float randomX = Random.Range(-3.25f, 3.25f);
            transform.position = new Vector3(randomX, 2.4f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            {
                if (player != null)
                {
                    player.Damage();
                }

                Destroy(this.gameObject);
            }
        }

        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            ScoreManager.gscore++;
        }
    }
}
