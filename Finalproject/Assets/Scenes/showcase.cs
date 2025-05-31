using UnityEngine;
using System.Collections;

public class CharacterShowcase : MonoBehaviour
{
    public GameObject[] characters;
    public float moveDuration = 0.5f;
    private int currentIndex = 0;
    private bool isSwitching = false;

    void Start()
    {   
        
            ShowOnly(currentIndex);
        
       

        
    }

    public void ShowNext()
    {
        if (isSwitching) return;
        int nextIndex = (currentIndex + 1) % characters.Length;
        StartCoroutine(SwitchCharacter(currentIndex, nextIndex, Vector3.right));
    }

    public void ShowPrevious()
    {
        if (isSwitching) return;
        int nextIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        StartCoroutine(SwitchCharacter(currentIndex, nextIndex, Vector3.left));
    }

    IEnumerator SwitchCharacter(int fromIndex, int toIndex, Vector3 direction)
    {
        isSwitching = true;
        GameObject fromChar = characters[fromIndex];
        GameObject toChar = characters[toIndex];

        toChar.SetActive(true);
        toChar.transform.position = fromChar.transform.position + direction * 9f;

        Vector3 startPos = fromChar.transform.position;
        Vector3 endPos = startPos - direction * 9f;
        Vector3 toStartPos = toChar.transform.position;
        Vector3 toEndPos = startPos;

        float t = 0;
        while (t < moveDuration)
        {
            t += Time.deltaTime;
            float lerp = t / moveDuration;

            fromChar.transform.position = Vector3.Lerp(startPos, endPos, lerp);
            toChar.transform.position = Vector3.Lerp(toStartPos, toEndPos, lerp);
            yield return null;
        }

        fromChar.SetActive(false);
      //  toChar.transform.position = startPos;
        currentIndex = toIndex;
        isSwitching = false;
    }

    void ShowOnly(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
    }
}
