using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Movimiento")]
    [SerializeField] private float movSpeed = 6f;
    private Vector2 velocity;

    [Header("Vida")]
    [SerializeField] private float maxLife = 100f;
    [SerializeField] private Image lifeBarFull;
    private float currentLife;

    [Header("Invulnerabilidad")]
    [SerializeField] private float fuerzaEmpuje = 10f; 
    [SerializeField] private float tiempoInvulnerable = 2f; 
    [SerializeField] private float intervaloParpadeo = 0.2f;

    private bool esInvulnerable = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentLife = maxLife;
        ActualizarBarraDeVida();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        velocity = new Vector2(horizontal, vertical).normalized * movSpeed;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Atleta") && !esInvulnerable)
        {
            currentLife -= 10f;
            currentLife = Mathf.Max(currentLife, 0);
            ActualizarBarraDeVida();

            EmpujarJugador(collision.transform.position);
            StartCoroutine(Invulnerabilidad());
        }

        if (collision.CompareTag("Enemy") && !esInvulnerable)
        {
            currentLife -= 10f;
            currentLife = Mathf.Max(currentLife, 0);
            ActualizarBarraDeVida();

            EmpujarJugador(collision.transform.position);
            StartCoroutine(Invulnerabilidad());
        }
    }
    private void EmpujarJugador(Vector2 enemigoPosicion)
    {
        Vector2 direccionEmpuje = new Vector2(transform.position.x - enemigoPosicion.x, 0).normalized;

        rb.velocity = Vector2.zero;
        rb.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode2D.Impulse);
    }

    private IEnumerator Invulnerabilidad()
    {
        esInvulnerable = true;
        float tiempo = 0f;
        while (tiempo < tiempoInvulnerable)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(intervaloParpadeo);
            tiempo += intervaloParpadeo;
        }

        spriteRenderer.enabled = true;
        esInvulnerable = false;
    }
    private void ActualizarBarraDeVida()
    {
        if (lifeBarFull != null)
        {
            lifeBarFull.fillAmount = currentLife / maxLife;
        }
    }
}
