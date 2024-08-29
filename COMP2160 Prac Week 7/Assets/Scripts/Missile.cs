using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float launchTime = 0;
    [SerializeField] private float speed = 5;
    private bool launched = false;

    private float maxHeight;

    [SerializeField] private Explosion explosionPrefab;

    private Backdrop backdrop;

    void Start()
    {
        launchTime = transform.position.x - launchTime;
        Camera camera = Camera.main;
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        SpriteRenderer sprite = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        maxHeight = topRight.y + sprite.bounds.extents.y;

        backdrop = FindObjectOfType<Backdrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (launched)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y > maxHeight)
            {
                Destroy(gameObject);
            }
        }
        else if (backdrop.transform.position.x >= launchTime)
        {
            launched = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        if (Layers.Instance.terrain.Contains(other))
        {
            if (launched)
            {
                Die(false);
            }
        }
        else
        {
            Die(true);
        }
    }

    private void Die(bool points)
    {
        Explosion explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(gameObject);

        if (points)
        {
            GameManager.Instance.ScoreMissile();
        }
    }

}
