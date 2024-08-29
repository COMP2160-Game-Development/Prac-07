using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    private PlayerActions playerActions;
    private InputAction shootAction;

    [SerializeField] private Bullet bulletPrefab;
    private Transform gun;
    [SerializeField] private float gunCooldown = 0.5f; // seconds
    private float gunTimer = 0;

    void Awake()
    {
        playerActions = new PlayerActions();
        shootAction = playerActions.Flying.Shoot;
    }

    void OnEnable()
    {
        shootAction.Enable();
    }

    void OnDisable()
    {
        shootAction.Disable();
    }
    void Update()
    {
        gunTimer -= Time.deltaTime;
        if (shootAction.ReadValue<float>() > 0 && gunTimer <= 0)
        {
            gunTimer = gunCooldown;
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
        }        
    }

}
