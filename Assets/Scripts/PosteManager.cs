using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosteManager : MonoBehaviour
{
    public int postesLigados = 0;
    // Start is called before the first frame update
    void Start()
    {
        postesLigados = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (postesLigados >= 5)
        {
            SceneManager.LoadScene("Victory"); // Switch to "Victory" scene
        }
    }

    public void posteLigado()
    {
        postesLigados++;
    }

    public int qtdPostesLigados()
    {
        return postesLigados;
    }
}
