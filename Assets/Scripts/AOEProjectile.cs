using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AOEProjectile : MonoBehaviour
{
    public float radius = 5f; // O raio do efeito de dano em área
    public float projectileDamage = 5f;
    //Esse delay seria pra quando tempo demoraria pra arma artirar
    public float delay = 0.5f;
    public bool fireEffect = false;
    public bool iceEffect = false;
    public bool heals = false;
    public bool lightEffect = false;
    public float duração = 0;

    // Por mim isso seria fixo e talvez uma classe pra cada? Pra nao ter que ficar fazendo todos assim
    public float slow = 0.2f;
    public float iceDuration = 3f;

    public float fireDamage = 0.2f;
    public float fireDuration = 3f;
    Collider[] colliders;

    public float duracao = 3;

    public GameObject fireParticles;
    public GameObject iceParticles;
    public GameObject healsParticles;
    public GameObject lightParticles;
    public GameObject normalParticles;
    private GameObject particles;


    private void Update()
    {
        
    }


    public void AplicarEfeitoEmArea()
    {
        if (fireEffect)
        {
            particles = Instantiate(fireParticles, transform.position, transform.rotation);
            particles.transform.localScale = new Vector3(3.5f, 1, 3.5f);
        }
        else if (iceEffect)
        {
            particles = Instantiate(iceParticles, transform.position, transform.rotation);

            // Aplicar a rotação de -90 graus no eixo X
            //particles.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

            //particles.transform.localScale = new Vector3(0.7f, 1, 1);
        }
        else
        {
            particles = Instantiate(normalParticles, transform.position, Quaternion.identity);

            // Aplicar a rotação de -90 graus no eixo X
            particles.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

            particles.transform.localScale = new Vector3(0.7f, 1, 1);
        }
        StartCoroutine(AplicarAoeCoroutine(duracao));
    }

    private IEnumerator AplicarAoeCoroutine(float duracao)
    {
        float intervalo = 1f; // Intervalo de tempo entre cada aplica��o de dano
        int numExplosoes = Mathf.FloorToInt(duracao / intervalo); // Quantidade de vezes que o dano ser� aplicado

        for (int i = 0; i < numExplosoes; i++)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            Debug.Log(i);

            foreach (Collider nearbyObject in colliders)
            {
                // Verifica se o objeto tem o script de vida do inimigo
                VidaInimigo vidaInimigo = nearbyObject.GetComponent<VidaInimigo>();
                if (vidaInimigo != null)
                {
                    vidaInimigo.TomarDano(projectileDamage);

                    if (iceEffect)
                    {
                        //Debug.Log("GELO");
                        vidaInimigo.AplicarLentidao(slow, iceDuration);
                    }

                    if (fireEffect)
                    {
                        vidaInimigo.AplicarDanoAoLongoDoTempo(fireDamage, fireDuration);
                    }
                }
            }
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        Destroy(particles);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Desenha uma esfera no editor para visualizar o raio de dano
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

