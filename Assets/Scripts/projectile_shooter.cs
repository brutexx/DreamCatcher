using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // O prefab do proj�til
    public Transform shootPoint; // O ponto de onde o proj�til ser� disparado
    public List<ProjectileConfig> shooterProperties = new List<ProjectileConfig>(); // Lista de propriedades
    private int indexer = 0; // �ndice para selecionar as propriedades

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Padr�o para bot�o esquerdo do mouse
        {
            ShootProjectile();
        }

        // Exemplo de como alterar o �ndice (voc� pode implementar isso de acordo com a l�gica do seu jogo)
        if (Input.GetKeyDown(KeyCode.L))
        {
            indexer = (indexer + 1) % shooterProperties.Count;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            indexer = (indexer - 1 + shooterProperties.Count) % shooterProperties.Count;
        }
    }

    void ShootProjectile()
    {
        // Instancia o proj�til no ponto de disparo com a mesma rota��o do personagem
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Obt�m o componente ProjectileProperties do proj�til instanciado
        ProjectileProperties projectileProperties = projectile.GetComponent<ProjectileProperties>();

        // Aplica as propriedades do array de acordo com o �ndice atual
        if (projectileProperties != null && shooterProperties.Count > 0)
        {
            ApplyProperties(projectileProperties, shooterProperties[indexer]);
        }
    }

    void ApplyProperties(ProjectileProperties target, ProjectileConfig source)
    {
        target.projectileSpeed = source.projectileSpeed;
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