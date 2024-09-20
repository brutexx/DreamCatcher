using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosteKiller : MonoBehaviour
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            VidaInimigo vidaInimigo = other.GetComponent<VidaInimigo>();
            vidaInimigo.Morrer();
        }
    }
}
