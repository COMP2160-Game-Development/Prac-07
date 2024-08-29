using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backdrop : MonoBehaviour
{
    [SerializeField] private float speed = 5; // m/s

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void RewindTo(float x)
    {
        Vector3 pos = transform.position;
        pos.x = x;
        transform.position = pos;
    }
}
