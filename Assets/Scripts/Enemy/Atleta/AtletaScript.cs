using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtletaScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Atleta ha tocado al jugador");
        }
    }
    private void OnBecameInvisible()
    {        
        Destroy(gameObject);
    }
}
