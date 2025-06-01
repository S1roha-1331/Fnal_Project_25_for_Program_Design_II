using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class SceneSwitcher : MonoBehaviour
{

    public Image darkPanel;

    public float duration = 1f;
    private void Update()
    {
        
    }
    public void LoadNextScene()
    {
      
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

      
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void DeactivateAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void Falling()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color c = darkPanel.color;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(0, 0.8f, elapsed / duration);
            darkPanel.color = c;
            Debug.Log("Panel Alpha set to: " + darkPanel.color.a);
            yield return null;
        }
    }
}
