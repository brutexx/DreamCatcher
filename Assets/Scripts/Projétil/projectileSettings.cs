using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSettings : MonoBehaviour
{
    public float projectileSpeed = 20f;
    public float projectileDamage = 5f;
    public bool aoe = false;
    public bool self = false;
    public bool fireEffect = false;
    public bool iceEffect = false;
    public bool heals = false;
    public bool shields = false;
    public float healAmount = 5f;
    public float shieldAmount = 5f;
    public bool lightEffect = false;
    public float slow = 0.2f;
    public float iceDuration = 3f;
    public float fireDamage = 0.2f;
    public float fireDuration = 3f;
    public int firstProperty = 0;
    public float delay = 0.5f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleFireEffect()
    {
        if (firstProperty == 0)
            firstProperty = 1;
        fireEffect = !fireEffect;
    }

    public void ToggleIceEffect()
    {
        if (firstProperty == 0)
            firstProperty = 2;
        iceEffect = !iceEffect;
    }

    public void DamageUp()
    {
        projectileDamage *= 2;
        delay *= 2;
    }

    public void DamageDown()
    {
        projectileDamage /= 2;
        delay /= 2;
    }

    public void ToggleAOE()
    {
        aoe = !aoe;
    }

    public void ToggleSelf()
    {
        self = !self;
    }

    public void ToggleHeals()
    {
        heals = true;
        healAmount *= 2;
        delay *= 2;
    }

    public void ToggleShields()
    {
        shields = true;
        shieldAmount *= 2;
        delay *= 2;
    }

    public void CreateSettings()
    {
        ProjectileShooter aux = player.GetComponent<ProjectileShooter>();
        if (aux != null)
        {
            // Cria uma c�pia das configura��es atuais
            ProjectileConfig copiedSettings = CreateCopy();

            // Adiciona a c�pia �s propriedades do atirador
            aux.shooterProperties.Add(copiedSettings);

            // Reinicia os par�metros para os valores padr�o
            ResetToDefault();
        }
    }

    private ProjectileConfig CreateCopy()
    {
        ProjectileConfig copy = new ProjectileConfig
        {
            projectileSpeed = this.projectileSpeed,
            projectileDamage = this.projectileDamage,
            fireEffect = this.fireEffect,
            iceEffect = this.iceEffect,
            heals = this.heals,
            shields = this.shields,
            slow = this.slow,
            lightEffect = this.lightEffect,
            iceDuration = this.iceDuration,
            fireDamage = this.fireDamage,
            fireDuration = this.fireDuration,
            firstProperty = this.firstProperty,
            delay = this.delay,
            aoe = this.aoe,
            self = this.self,
            healAmount = this.healAmount,
            shieldAmount = this.shieldAmount,
        };
        return copy;
    }

    public void ResetToDefault()
    {
        projectileSpeed = 20f;
        projectileDamage = 5f;
        fireEffect = false;
        iceEffect = false;
        heals = false;
        shields = false;
        lightEffect = false;
        slow = 0.2f;
        iceDuration = 3f;
        fireDamage = 0.2f;
        fireDuration = 3f;
        firstProperty = 0;
        delay = 0.5f;
        aoe = false;
        self = false;
        healAmount = 5f;
        shieldAmount = 5f;
    }
}


