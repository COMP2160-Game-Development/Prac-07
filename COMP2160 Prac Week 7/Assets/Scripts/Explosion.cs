using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Explosion : MonoBehaviour
{
    void Start()
    {
        // Destory self after the particle system has finished
        ParticleSystem particles = GetComponent<ParticleSystem>();        
        Destroy(gameObject, particles.main.duration);
    }

}
