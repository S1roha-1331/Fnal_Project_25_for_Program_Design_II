using UnityEngine;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public string interactKey = "e";
    public TextMeshProUGUI promptText; // UI 提示用
    public GameObject interactionPanel; // 互動後要打開的對話或商店

    [SerializeField] private DialogueManager dialogueManager;

    private bool playerInRange = false;

    private void Start()
    {
        if (promptText != null)
            promptText.gameObject.SetActive(false);

        if (interactionPanel != null)
            interactionPanel.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            Debug.Log("與 NPC 互動！");
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue();
            }
            else if (interactionPanel != null)
            {
                interactionPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (promptText != null)
                promptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (promptText != null)
                promptText.gameObject.SetActive(false);

            if (interactionPanel != null)
                interactionPanel.SetActive(false);
        }
    }
}
