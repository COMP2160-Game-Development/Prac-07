using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Explosion explosionPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Explosion explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(gameObject);

        GameManager.Instance.ScoreRadar();
    }
}
