using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float gravity = 10;
    private Vector2 velocity;
    public Vector2 Velocity
    {
        get
        {
            return velocity;
        }

        set
        {
            velocity.y -= value.y;
        }
    }

    void Update()
    {
        velocity.y -= gravity * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}
