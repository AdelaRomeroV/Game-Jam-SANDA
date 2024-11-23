using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movimiento")]
    [SerializeField] private float movSpeed;
    Vector2 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity.Normalize();
        rb.velocity = velocity * movSpeed;
    }
}
