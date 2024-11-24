using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueIG : MonoBehaviour
{
    [SerializeField] private bool canInteract = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            Debug.Log("Juego pausado, diálogo activado.");
        }
    }
}
