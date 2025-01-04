using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] dialogueLines;
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject canva;
    [SerializeField] private float deactivateDelay;
    [SerializeField] private GameObject interactionSignal;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite characterSprite; 

    private int index;
    private bool isDialogueActive = false;
    private bool isTyping = false;
    private Transform player;
    private Coroutine typeLineCoroutine;

    private void Start()
    {
        text.text = string.Empty;
        if (interactionSignal != null)
        {
            interactionSignal.SetActive(false);
        }

        player = GameObject.FindWithTag("Player").transform;

     
        if (characterImage != null)
        {
            characterImage.gameObject.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        StopAllCoroutines();
        text.text = string.Empty;

        if (isDialogueActive)
        {
            StopDialogue();
        }

        Time.timeScale = 0;

        if (!canva.activeInHierarchy)
        {
            canva.SetActive(true);
        }

      
        if (characterImage != null && characterSprite != null)
        {
            characterImage.sprite = characterSprite;
            characterImage.gameObject.SetActive(true);
        }

        index = 0;
        isDialogueActive = true;
        typeLineCoroutine = StartCoroutine(TypeLine());
    }

    public void StopAllDialogues()
    {
        StopAllCoroutines();
        text.text = string.Empty;
        canva.SetActive(false);

        if (characterImage != null)
        {
            characterImage.gameObject.SetActive(false);
        }

        Time.timeScale = 1;
        isDialogueActive = false;
        isTyping = false;
    }

    private IEnumerator TypeLine()
    {
        isTyping = true;
        text.text = string.Empty;

        foreach (char c in dialogueLines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        isTyping = false;
    }

    private void Update()
    {
        if (!isDialogueActive) return;

       
        if (player != null && Vector2.Distance(player.position, transform.position) > maxDistance)
        {
            StopDialogue();
            return;
        }

      
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (typeLineCoroutine != null)
            {
                StopCoroutine(typeLineCoroutine);
                typeLineCoroutine = null;
            }

            text.text = dialogueLines[index];
            isTyping = false;
        }

      
        if (!isTyping && Input.GetKeyDown(KeyCode.Return))
        {
            if (index < dialogueLines.Length - 1)
            {
                index++;
                if (typeLineCoroutine != null)
                {
                    StopCoroutine(typeLineCoroutine);
                }

                typeLineCoroutine = StartCoroutine(TypeLine());
            }
            else
            {
                StartCoroutine(DeactivateCanvasAfterDelay());
            }
        }
    }

    private IEnumerator DeactivateCanvasAfterDelay()
    {
        yield return new WaitForSecondsRealtime(deactivateDelay);
        StopDialogue();
    }

    public void StopDialogue()
    {
        if (typeLineCoroutine != null)
        {
            StopCoroutine(typeLineCoroutine);
            typeLineCoroutine = null;
        }

        canva.SetActive(false);
        text.text = string.Empty;

        if (characterImage != null)
        {
            characterImage.gameObject.SetActive(false);
        }

        Time.timeScale = 1; 
        isDialogueActive = false;
        isTyping = false;
    }

    public void ShowInteractionSignal(bool show)
    {
        if (interactionSignal != null)
        {
            interactionSignal.SetActive(show);
        }
    }
}
