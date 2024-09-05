using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // O prefab do projétil
    public Transform shootPoint; // O ponto de onde o projétil será disparado
    public List<ProjectileConfig> shooterProperties = new List<ProjectileConfig>(); // Lista de propriedades
    private int indexer = 0; // Índice para selecionar as propriedades

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Padrão para botão esquerdo do mouse
        {
            ShootProjectile();
        }

        // Exemplo de como alterar o índice (você pode implementar isso de acordo com a lógica do seu jogo)
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
        // Instancia o projétil no ponto de disparo com a mesma rotação do personagem
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Obtém o componente ProjectileProperties do projétil instanciado
        ProjectileProperties projectileProperties = projectile.GetComponent<ProjectileProperties>();

        // Aplica as propriedades do array de acordo com o índice atual
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
        target.slow = source.slow;
        target.lightEffect = source.lightEffect;
        target.iceDuration = source.iceDuration;
        target.fireDamage = source.fireDamage;
        target.fireDuration = source.fireDuration;
        target.firstProperty = source.firstProperty;
        target.delay = source.delay;
        target.ChangeLight();
    }
}