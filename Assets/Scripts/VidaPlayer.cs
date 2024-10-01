using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;
    private float velocidadeOriginal;
    public float shield = 0f;

    private float reducaoVelocidadeAtual = 0f;

    private Coroutine coroutineLentidao;

    void Start()
    {
        vidaAtual = vidaMaxima;
        velocidadeOriginal = GetComponent<PlayerController>().playerSpeed;
    }

    public void TomarDano(float dano)
    {
        if (shield > 0)
        {
            float danoAux = dano - shield;
            shield -= dano;
            if (shield < 0)
                shield = 0;
            if (danoAux < 0)
                dano = 0;
            else
                dano -= danoAux;
        }
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Morrer();
        }

    }

    public void GanharShield(float shieldGanho)
    {
        shield += shieldGanho;
    }

    public void GanharVida(float vida)
    {
        vidaAtual += vida;

        if (vidaAtual > vidaMaxima)
            vidaAtual = vidaMaxima;
    }

    void Morrer()
    {
        SceneManager.LoadScene("GameOver"); // Switch to "Victory" scene
    }

    public void AplicarLentidao(float porcentagemReducao, float duracao)
    {
        coroutineLentidao = StartCoroutine(AplicarLentidaoCoroutine(porcentagemReducao, duracao));
    }

    private IEnumerator AplicarLentidaoCoroutine(float porcentagemReducao, float duracao)
    {
        // Acumula a redução da velocidade
        reducaoVelocidadeAtual += porcentagemReducao;
        PlayerController player = GetComponent<PlayerController>();
        player.playerSpeed = velocidadeOriginal * (1 - reducaoVelocidadeAtual);

        yield return new WaitForSeconds(duracao);

        // Quando a duração do efeito terminar, subtrai a redução aplicada dessa instância
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
