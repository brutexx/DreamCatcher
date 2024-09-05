using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public GameObject panel;
    public GameObject projectile;
    public GameObject aoe;
    public GameObject self;
    public GameObject level;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void PanelOn() {
        level.SetActive(false);
        panel.SetActive(true);
    }

    public void LevelOn()
    {
        level.SetActive(true);
        panel.SetActive(false);
        projectile.SetActive(false);
        aoe.SetActive(false);
        self.SetActive(false);
    }
}
