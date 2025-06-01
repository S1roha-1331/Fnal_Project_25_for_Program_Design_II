using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class loadcur : MonoBehaviour
{
    public SceneSwitcher a;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {


        // 判斷是否是特定標籤的物件
        if (other.CompareTag("Player"))
        {



            a.Falling();

            //StartCoroutine(FadeIn());
      //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }



    
    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    


}

