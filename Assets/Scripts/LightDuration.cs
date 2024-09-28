using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDuration : MonoBehaviour
{
    public float range = 10f; // Range da Point Light
    public float maxDamage = 10f; // Dano máximo
    public LayerMask enemyLayer; // Camada dos inimigos
    public float damageInterval = 2f; // Intervalo de tempo entre danos
    private float nextDamageTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds(5f));
    }

    void Update()
    {
        if (Time.time >= nextDamageTime)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, range, enemyLayer);
            foreach (Collider enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                float damage = CalculateDamage(distance);
                enemy.GetComponent<VidaInimigo>().TomarDano(damage);
            }
            nextDamageTime = Time.time + damageInterval; // Atualiza o próximo tempo de dano
        }
    }

    private float CalculateDamage(float distance)
    {
        // Calcula o dano baseado na distância
        float damage = Mathf.Lerp(maxDamage, 0, distance / range);
        return damage;
    }


    private IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
