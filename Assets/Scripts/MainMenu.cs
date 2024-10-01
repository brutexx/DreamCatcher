using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nome;

    // Start is called before the first frame update
    public void StartGame()
    {
        // Carrega a próxima cena (certifique-se de configurar as cenas no Build Settings)
        SceneManager.LoadScene(nome);
    }

    // Função chamada ao clicar no botão "Exit"
    public void ExitGame()
    {
        // Fecha o jogo
        Application.Quit();
        // Debug para testar no editor (pois Application.Quit não funciona no editor)
        Debug.Log("Saiu do jogo!");
    }
}
