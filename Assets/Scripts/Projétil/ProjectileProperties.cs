using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public Rigidbody rb;
    // "speed" está em BulletController.
    public float projectileDamage = 5f;
    //Esse delay seria pra quando tempo demoraria pra arma artirar
    public float delay = 0.5f;
    public bool fireEffect = false;
    public bool iceEffect = false;
    public bool heals = false;
    public bool shields = false;
    public float healAmount = 5f;
    public float shieldAmount = 5f;
    public bool lightEffect = false;
    public Light light;
    public bool aoe = false;
    public bool self = false;

    // Por mim isso seria fixo e talvez uma classe pra cada? Pra nao ter que ficar fazendo todos assim
    public float slow = 0.2f;
    public float iceDuration = 3f;

    public float fireDamage = 0.2f;
    public float fireDuration = 3f;

    public int firstProperty = 0;

    public float duracao = 4;

    public float radius = 5f;

    float initDist = 0;

    public GameObject aoeAreaPrefab;

    public GameObject lightPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        initDist = gameObject.transform.position.x;
    }


    public void ChangeLight()
    {
        light = GetComponent<Light>();
        if (light != null)
        {
            if (firstProperty == 1)
                light.color = Color.red;
            else if (firstProperty == 2)
                light.color = Color.blue;
            else
                light.color = Color.grey;
        }
    }
   
    public void ShootSelf (GameObject player)
    {
        VidaPlayer vidaPlayer = player.GetComponent<VidaPlayer>();
        if (vidaPlayer != null)
        {
            if (!heals && !shields)
                vidaPlayer.TomarDano(projectileDamage);
            if (heals)
                vidaPlayer.GanharVida(healAmount);
            if (shields)
                vidaPlayer.GanharShield(shieldAmount);

            if (iceEffect)
            {
                vidaPlayer.AplicarLentidao(slow, iceDuration);
            }

            if (fireEffect)
            {
                vidaPlayer.AplicarDanoAoLongoDoTempo(fireDamage, fireDuration);
            }
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        
        if (!aoe && other.CompareTag("Enemy"))
        {
            VidaInimigo vidaInimigo = other.GetComponent<VidaInimigo>();
            if (vidaInimigo != null)
            {
                vidaInimigo.TomarDano(projectileDamage);

                if (iceEffect)
                {
                    vidaInimigo.AplicarLentidao(slow, iceDuration);
                }

                if (fireEffect)
                {
                    vidaInimigo.AplicarDanoAoLongoDoTempo(fireDamage, fireDuration);
                }
            }

        }
        
        if (aoe && !other.CompareTag("Player"))
        {
            Explode();
        }

        if (!other.CompareTag("Player") && !other.CompareTag("Air") && !other.CompareTag("Enemy") || aoe)
        {
            GameObject aux =  Instantiate(lightPrefab, transform.position, transform.rotation);
            Light auxLight =  aux.GetComponent<Light>();
            if (firstProperty == 1)
                auxLight.color = Color.red;
            else if (firstProperty == 2)
                auxLight.color = Color.blue;
            else
                auxLight.color = Color.white;
        }


        if (!other.CompareTag("Player") && !other.CompareTag("Air"))
            Destroy(gameObject);
    }

    void Explode()
    {
        GameObject aoeArea = Instantiate(aoeAreaPrefab, transform.position, transform.rotation);
        
        AOEProjectile aoeProjectile = aoeArea.GetComponent<AOEProjectile>();
        ApplyProperties(aoeProjectile);
        // Obt�m todos os colliders dentro do raio especificado
        aoeProjectile.AplicarEfeitoEmArea();

        // Opcional: Adicione um efeito visual ou destrua o objeto ap�s o dano
        // Destroy(gameObject);
    }

    void ApplyProperties(AOEProjectile target)
    {
        target.projectileDamage = projectileDamage;
        target.fireEffect = fireEffect;
        target.iceEffect = iceEffect;
        target.heals = heals;
        target.slow = slow;
        target.lightEffect = lightEffect;
        target.iceDuration = iceDuration;
        target.fireDamage = fireDamage;
        target.duracao = duracao;
        target.healAmount= healAmount;
        target.shields = shields;
        target.shieldAmount = shieldAmount;
}

}
