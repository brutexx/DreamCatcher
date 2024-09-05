using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiroCreator : MonoBehaviour
{
    public string sceneName; // Corrigido: Declara��o correta da vari�vel
    public GameObject panel;
    public GameObject level;
    public GameObject options;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Verifica a entrada do teclado enquanto o jogador est� dentro do trigger
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Verifica se o player est� dentro do trigger usando uma flag
            if (isPlayerInTrigger)
            {
                ChangeScene();
            }
        }
    }

    private bool isPlayerInTrigger = false; // Flag para verificar se o jogador est� dentro do trigger

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Corrigido: Usar CompareTag com "C" mai�sculo
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

    public void ChangeScene()
    {
        level.SetActive(false);
        panel.SetActive(true);
        options.SetActive(true);
    }
}
