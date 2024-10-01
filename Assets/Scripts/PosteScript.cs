using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosteScript : MonoBehaviour
{
    public PosteManager posteManagerScript;
    public GameObject killerLight;


    // Update is called once per frame
    void Update()
    {
        // Verifica a entrada do teclado enquanto o jogador está dentro do trigger
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Verifica se o player está dentro do trigger usando uma flag
            if (isPlayerInTrigger)
            {
                killerLight.SetActive(true); // Activates the light
                posteManagerScript.posteLigado();
                this.enabled = false; // Disables this script
            }
        }
    }

    private bool isPlayerInTrigger = false; // Flag para verificar se o jogador está dentro do trigger

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Corrigido: Usar CompareTag com "C" maiúsculo
        {
            isPlayerInTrigger = true; // Define a flag como true quando o jogador entra no trigger
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false; // Define a flag como false quando o jogador sai do trigger
        }
    }
}
