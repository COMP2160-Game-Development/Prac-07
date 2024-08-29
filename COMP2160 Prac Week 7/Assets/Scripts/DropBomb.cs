using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropBomb : MonoBehaviour
{
    private PlayerActions playerActions;
    private InputAction bombAction;

    [SerializeField] private Bomb bombPrefab;
    [SerializeField] private float dropSpeed = 2.0f;

    [SerializeField] private float bombCooldown = 0.5f; // seconds
    private float bombTimer = 0;

    void Awake()
    {
        playerActions = new PlayerActions();
        bombAction = playerActions.Flying.Bomb;
    }

    void OnEnable()
    {
        bombAction.Enable();
    }

    void OnDisable()
    {
        bombAction.Disable();
    }

    void Update()
    {
        bombTimer -= Time.deltaTime;
        if (bombAction.ReadValue<float>() > 0 && bombTimer <= 0)
        {
            bombTimer = bombCooldown;
            Bomb bomb = Instantiate(bombPrefab);
            bomb.transform.position = transform.position;
            Vector2 drop = new Vector2(0, dropSpeed);
            bomb.Velocity = drop;
        }        
    }

}
