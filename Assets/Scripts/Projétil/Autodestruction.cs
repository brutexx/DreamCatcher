using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruction : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy = 5f;
    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
