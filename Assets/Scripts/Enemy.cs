using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Caso em algum momento quisermos usar de patrulha
    //public Transform[] pontosDePatrulha;
    //private int pontoAtual = 0;

    [Header("Movement Settings")]
    public float velocidade = 2.0f;
    public NavMeshAgent enemy;

    [Header("Attack Settings")]
    public int damageAmount = 10;         // Damage per attack
    public float attackRate = 1.0f;       // Time between attacks in seconds
    private float lastAttackTime = 0f;    // Timestamp of the last attack

    private GameObject playerObject;
    private Transform playerTransform;
    private VidaPlayer playerHealth;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        // Get the playerTransform
        playerObject = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
        // Get the Animator component attached to the enemy GameObject
        animator = GetComponent<Animator>();
        // Set the NavMeshAgent's speed to the specified 'velocidade'
        enemy.speed = velocidade;
    }

    void Update()
    {
        enemy.SetDestination(playerTransform.position);  

        // Attack the playerTransform
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Continue moving towards the playerTransform
        enemy.SetDestination(playerTransform.position);

        // Handle movement animations
        HandleMovementAnimations();
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<VidaPlayer>();
            // Handle attack
            AttemptAttack();
        }
    }

    private void HandleMovementAnimations ()
    {
        // Get the current velocity of the NavMeshAgent
        Vector3 velocity = enemy.velocity;

        // Transform the velocity to local space
        Vector3 localDirection = transform.InverseTransformDirection(velocity.normalized);

        // Set Animator parameters based on movement direction
        animator.SetFloat("MoveX", localDirection.x);
        animator.SetFloat("MoveZ", localDirection.z);
    }

    // Method to attempt an attack
    private void AttemptAttack()
    {
        // Check if enough time has passed since the last attack
        if (Time.time - lastAttackTime >= attackRate)
        {
            Attack();
            lastAttackTime = Time.time;
        }

        // Optionally, handle attack animations
        if (animator != null)
        {
            animator.SetTrigger("Attack");  // Ensure you have an "Attack" trigger in the Animator
        }
    }

    private void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TomarDano(damageAmount);
        }

        animator.CrossFade(Animator.StringToHash("Jump"), 0.1f);
    }

    // Caso em algum momentos quisermos usar de patrulha
    /*
    void Patrulhar()
    {
        if (pontosDePatrulha.Length == 0)
            return;

        Transform destino = pontosDePatrulha[pontoAtual];
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino.position) < 0.2f)
        {
            pontoAtual = (pontoAtual + 1) % pontosDePatrulha.Length;
        }
    }
    */
}
