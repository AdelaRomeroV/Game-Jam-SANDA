using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] open;
    [SerializeField] private float speed;
    [SerializeField] private GameObject canva;
    [SerializeField] private float deactivateDelay;
    [SerializeField] private GameObject objectToDestroy;
    [SerializeField] private bool skipEnabled = true;

    private int index;
    private bool actionCompleted = false;

    private void Start()
    {
        text.text = string.Empty;
    }

    private void Update()
    {

        if (skipEnabled && !actionCompleted && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Tecla Z presionada. Saltando diálogo.");
            SkipDialogue();
        }
    }

    public void StartDialogue()
    {
        if (!canva.activeInHierarchy)
        {
            canva.SetActive(true);
        }

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;

        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (var c in open[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(speed);
        }

    }
    public void ActivarPlayer()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
    }
    public void NextLine()
    {
        if (index < open.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StartCoroutine(DeactivateCanvasAfterDelay());
        }
    }

    private IEnumerator DeactivateCanvasAfterDelay()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        yield return new WaitForSeconds(deactivateDelay);
        canva.SetActive(false);
    }

    private void SkipDialogue()
    {
        actionCompleted = true;

        text.text = string.Empty;

        if (canva != null)
        {
            canva.SetActive(false);
        }

        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
            Debug.Log("Objeto eliminado: " + objectToDestroy.name);
        }

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;

        skipEnabled = false;

        Debug.Log("Diálogo saltado y acción ejecutada.");
    }
}
