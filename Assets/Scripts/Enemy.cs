using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Caso em algum momento quisermos usar de patrulha
    //public Transform[] pontosDePatrulha;
    //private int pontoAtual = 0;

    public float velocidade = 2.0f;

    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to the enemy GameObject
        animator = GetComponent<Animator>();
        // Set the NavMeshAgent's speed to the specified 'velocidade'
        enemy.speed = velocidade;
    }

    void Update()
    {
        enemy.SetDestination(player.position);  

        // Get the current velocity of the NavMeshAgent
        Vector3 velocity = enemy.velocity;

        // Transform the velocity to local space
        Vector3 localDirection = transform.InverseTransformDirection(velocity.normalized);

        // Set Animator parameters based on movement direction
        animator.SetFloat("MoveX", localDirection.x);
        animator.SetFloat("MoveZ", localDirection.z);
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
