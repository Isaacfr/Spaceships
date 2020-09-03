using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if(transform.position.y > 2.15f)
        {
            Destroy(this.gameObject);
        }
    }
}
