using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Rect flightRect;
    private PlayerActions playerActions;
    private InputAction movementAction;

    [SerializeField] private Explosion explosionPrefab;

    private SpriteRenderer sprite;

    void Awake()
    {
        playerActions = new PlayerActions();
        movementAction = playerActions.Flying.Movement;
    }

    void OnEnable()
    {
        movementAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();
    }

    void Start()
    {
        // get the camera rect
        // note this assumes the window is aligned with the world x/y axes
        Camera camera = Camera.main;
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));

        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();

        // shrink the box by the size of the sprite
        flightRect.xMin = bottomLeft.x + sprite.bounds.extents.x;
        flightRect.xMax = topRight.x - sprite.bounds.extents.x;
        flightRect.yMin = bottomLeft.y + sprite.bounds.extents.y;
        flightRect.yMax = topRight.y - sprite.bounds.extents.y;
    }

    void Update()
    {
        float vx = movementAction.ReadValue<Vector2>().x;
        float vy = movementAction.ReadValue<Vector2>().y;

        Vector3 velocity = new Vector3(vx, vy, 0) * speed;
        transform.Translate(velocity * Time.deltaTime);

        // clamp to stay on screen
        transform.localPosition = flightRect.Clamp(transform.localPosition);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;

        // die if colliding with terrain, missles or radars
        if (!Layers.Instance.checkpoint.Contains(other))
        {
            Die();
        }
    }

    private void Die()
    {
        // hide the ship
        gameObject.SetActive(false);

        // create an explosion and wait for it to complete before telling the GameManager
        Explosion explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;

        // tell the GameManager
        GameManager.Instance.Die();
    }

    public void Revive()
    {
        gameObject.SetActive(true);
    }
}
