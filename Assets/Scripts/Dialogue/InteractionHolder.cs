using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private ObjectDialogue currentDialogue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentDialogue = collision.gameObject.GetComponent<ObjectDialogue>();

        if (currentDialogue != null && currentDialogue.TryGetComponent(out ObjectDialogue dialogueWithSignal))
        {
            Debug.Log("Interacción disponible. Presiona 'E' para interactuar.");
            dialogueWithSignal.ShowInteractionSignal(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ObjectDialogue>() == currentDialogue)
        {
            if (currentDialogue != null)
            {
                currentDialogue.ShowInteractionSignal(false);
            }
            currentDialogue = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentDialogue != null)
        {
            currentDialogue.StartDialogue();
        }
    }
}
