using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtletaScript : MonoBehaviour
{
    public float speed = 5f; 

    void Start()
    {
        
    }

    void Update()
    {   
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {        
        Destroy(gameObject);
    }
}
