using UnityEngine;

public class loadnext : MonoBehaviour
{
   public LoadingScene a;
    public int sceneid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        // 判斷是否是特定標籤的物件
        if (other.CompareTag("Player"))
        {



            a.LoadScene(sceneid);

            //StartCoroutine(FadeIn());
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
