using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private float bulletHitMissDistance = 25f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;
    private InputAction switchAction;

    public List<ProjectileConfig> shooterProperties = new List<ProjectileConfig>(); // Lista de propriedades
    private int indexer = 0; // �ndice para selecionar as propriedades

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        shootAction = playerInput.actions["Shoot"];
        switchAction = playerInput.actions["Switch"];
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shootAction.performed += _ => ShootGun();
        switchAction.performed += ctx => SwitchGun(ctx.ReadValue<float>());
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void SwitchGun(float fdirection)
    {
        int direction = Mathf.RoundToInt(fdirection);
        int count = shooterProperties.Count;

        if (count != 0)
        {
            indexer = (indexer + direction + count) % count;
        }
    }

    private void ShootGun()
    {
        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        ProjectileProperties bulletProperties = bullet.GetComponent<ProjectileProperties>();

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
        }
        else
        {
            bulletController.target = cameraTransform.position + cameraTransform.forward * bulletHitMissDistance;
            bulletController.hit = false;
        }

        // Aplica as propriedades do array de acordo com o �ndice atual
        if (bulletProperties != null && shooterProperties.Count > 0)
        {
            ApplyProperties(bulletProperties, shooterProperties[indexer]);
        }

        if (bulletProperties.self)
            bulletProperties.ShootSelf(gameObject);
    }

    void Update()
    {

        // ------ Movimento ------ //
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Pega os inputs de movimento do jogador
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        // Saber qual dire��o � "para frente"
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        // Move o jogador
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Rotate towards camera direction
        
        // Pega a dire��o
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        // Olha para a dire��o (com interpola��o)
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void ApplyProperties(ProjectileProperties target, ProjectileConfig source)
    {
        // Por enquanto "Speed" n�o est� em ProjectileProperties, e sim em BulletController.
        //target.projectileSpeed = source.projectileSpeed;
        target.projectileDamage = source.projectileDamage;
        target.fireEffect = source.fireEffect;
        target.iceEffect = source.iceEffect;
        target.heals = source.heals;
        target.shields = source.shields;
        target.slow = source.slow;
        target.lightEffect = source.lightEffect;
        target.iceDuration = source.iceDuration;
        target.fireDamage = source.fireDamage;
        target.fireDuration = source.fireDuration;
        target.firstProperty = source.firstProperty;
        target.delay = source.delay;
        target.aoe = source.aoe;
        target.self = source.self;
        target.healAmount = source.healAmount;
        target.shieldAmount = source.shieldAmount;
        target.ChangeLight();
    }
}