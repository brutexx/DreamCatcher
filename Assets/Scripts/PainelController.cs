using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PainelControleer : MonoBehaviour
{
    public GameObject optionsPanel, projectilePanel, aoePanel, selfPanel;
    private List<GameObject> buttons = new List<GameObject>();
    public GameObject buttonPrefab; // Prefab do botão a ser instanciado
    public Canvas canvas; // Referência ao Canvas onde o botão será exibido


    public void ShowProjectile()
    {
        optionsPanel.SetActive(false);
        projectilePanel.SetActive(true);

    }

    public void ShowAoe()
    {
        optionsPanel.SetActive(false);
        aoePanel.SetActive(true);

    }

    public void ShowSelf()
    {
        optionsPanel.SetActive(false);
        selfPanel.SetActive(true);

    }

    public void ShowOptions() { 
        optionsPanel.SetActive(true);
        projectilePanel.SetActive(false);
        aoePanel.SetActive(false);
        selfPanel.SetActive(false);
    }

    public void CreateButton(string texto)
    {
        // Instancia o botão como um filho do Canvas
        GameObject newButtonObject = Instantiate(buttonPrefab, canvas.transform);
        buttons.Add(newButtonObject);

        // Ativa o botão se ele estiver desativado
        newButtonObject.SetActive(true);

        RectTransform rectTransform = newButtonObject.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(48.7605f, 160.3336f);
        }



        // Ajusta o texto do botão (opcional)
        Text buttonText = newButtonObject.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = texto;
        }
    }
    }
