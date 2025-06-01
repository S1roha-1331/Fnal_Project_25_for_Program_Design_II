using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("對話內容")]
    [TextArea(2, 5)] public string[] firstDialogueLines;
    [TextArea(2, 5)] public string[] repeatDialogueLines;

    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button closeButton;

    [SerializeField] private TypewriterEffect typewriter;

    private string[] currentLines;
    private int currentLineIndex = 0;
    private bool isTalking = false;
    private bool hasTalked = false;

    void Start()
    {
        dialoguePanel.SetActive(false);
        closeButton.onClick.AddListener(EndDialogue);
    }
    public void StartDialogue()
    {
        currentLineIndex = 0;
        currentLines = hasTalked ? repeatDialogueLines : firstDialogueLines; 
        dialoguePanel.SetActive(true);
        isTalking = true;

        hasTalked = true;

        StartTyping();
    }

    void Update()
    {
        if (isTalking && Input.GetMouseButtonDown(0))
        {
            AdvanceDialogue();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        // 防呆：如果根本沒內容，就直接結束
        if (currentLines == null || currentLines.Length == 0)
        {
            Debug.LogWarning("沒有任何對話可顯示！");
            EndDialogue();
            return;
        }

        // 如果正在打字 → 快速顯示整句
        if (typewriter.IsTyping)
        {
            typewriter.Stop();
            dialogueText.text = currentLines[currentLineIndex];
            return;
        }

        // 正常下一句流程
        currentLineIndex++;
        if (currentLineIndex < currentLines.Length)
        {
            StartTyping();
        }
        else
        {
            currentLineIndex = 0; // ✅ 從頭開始播
            StartTyping();        // ✅ 再次播放第一句
        }
    }

    private void StartTyping()
    {
        string line = currentLines[currentLineIndex];
        typewriter.Run(line, dialogueText);
    }


    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isTalking = false;
    }
}