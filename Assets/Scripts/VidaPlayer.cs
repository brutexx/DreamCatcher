using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;
    private float velocidadeOriginal;


    private bool slow = false;

    private float reducaoVelocidadeAtual = 0f;

    private Coroutine coroutineLentidao;

    void Start()
    {
        vidaAtual = vidaMaxima;
        velocidadeOriginal = GetComponent<PlayerController>().playerSpeed;
    }

    public void TomarDano(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        // Aqui voc� pode adicionar efeitos de morte, como anima��o, part�culas, etc.
       
    }

    public void AplicarLentidao(float porcentagemReducao, float duracao)
    {
        coroutineLentidao = StartCoroutine(AplicarLentidaoCoroutine(porcentagemReducao, duracao));
    }

    private IEnumerator AplicarLentidaoCoroutine(float porcentagemReducao, float duracao)
    {
        // Acumula a redu��o da velocidade
        reducaoVelocidadeAtual += porcentagemReducao;
        PlayerController player = GetComponent<PlayerController>();
        player.playerSpeed = velocidadeOriginal * (1 - reducaoVelocidadeAtual);

        yield return new WaitForSeconds(duracao);

        // Quando a dura��o do efeito terminar, subtrai a redu��o aplicada dessa inst�ncia
        reducaoVelocidadeAtual -= porcentagemReducao;

        if (reducaoVelocidadeAtual < 0)
            reducaoVelocidadeAtual = 0;

        player.playerSpeed = velocidadeOriginal * (1 - reducaoVelocidadeAtual);
    }

    public void AplicarDanoAoLongoDoTempo(float danoPorSegundo, float duracao)
    {
        StartCoroutine(AplicarDanoAoLongoDoTempoCoroutine(danoPorSegundo, duracao));
    }

    private IEnumerator AplicarDanoAoLongoDoTempoCoroutine(float danoPorSegundo, float duracao)
    {
        float tempoPassado = 0f;

        while (tempoPassado < duracao)
        {
            TomarDano(danoPorSegundo);
            tempoPassado += 1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
