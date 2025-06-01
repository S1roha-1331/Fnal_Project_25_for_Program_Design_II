using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class loadcur : MonoBehaviour
{
    public Image darkPanel; 
    public float duration = 1f;
    //public SceneSwitcher a;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {


        // �P�_�O�_�O�S�w���Ҫ�����
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
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(0, 0.8f, elapsed / duration);
            darkPanel.color = c;
            Debug.Log("Panel Alpha set to: " + darkPanel.color.a);
            yield return null;
        }
        c.a = 0.8f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }


    



}

