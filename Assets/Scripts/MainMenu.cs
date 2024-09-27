using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        // Carrega a pr�xima cena (certifique-se de configurar as cenas no Build Settings)
        SceneManager.LoadScene("Sample");
    }

    // Fun��o chamada ao clicar no bot�o "Exit"
    public void ExitGame()
    {
        // Fecha o jogo
        Application.Quit();
        // Debug para testar no editor (pois Application.Quit n�o funciona no editor)
        Debug.Log("Saiu do jogo!");
    }
}
