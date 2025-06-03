using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class loadcur : MonoBehaviour
{
    public Image darkPanel; 
    public float duration = 1.5f;
    public GameObject died;
    //public SceneSwitcher a;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {


        // 判斷是否是特定標籤的物件
        if (other.CompareTag("Player"))
        {



            Falling();

            //StartCoroutine(FadeIn());
        

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
        Color d = died.GetComponent<TextMeshProUGUI>().color;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(0, 0.6f, elapsed / duration);
            d.a = Mathf.Lerp(0, 0.8f, elapsed / duration);
            darkPanel.color = c;
            died.GetComponent<TextMeshProUGUI>().color = d;
            Debug.Log("Panel Alpha set to: " + darkPanel.color.a);
            yield return null;
        }
      //  c.a = 0.8f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }


    



}

