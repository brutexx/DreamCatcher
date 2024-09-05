using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] pontosDePatrulha;
    public float velocidade = 2.0f;
    private int pontoAtual = 0;

    void Update()
    {
        Patrulhar();
    }

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
}
