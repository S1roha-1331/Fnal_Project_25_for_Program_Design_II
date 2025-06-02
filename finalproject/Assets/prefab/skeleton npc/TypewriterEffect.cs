using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;

    public void Run(string textToType, TextMeshProUGUI textLabel)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TextMeshProUGUI textLabel)
    {
        textLabel.text = "";
        foreach (char c in textToType)
        {
            textLabel.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public bool IsTyping => typingCoroutine != null;
    public void Stop()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
    }
}
