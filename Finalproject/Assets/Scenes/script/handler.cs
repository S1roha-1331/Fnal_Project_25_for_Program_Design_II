using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using System.Collections.Generic;
public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance;
    public GameObject LoadingScreen;
    public GameObject LoadingCanvas;
    public GameObject LoadingScreen1;
    public GameObject LoadingCanvas1;
    public static Transform parent;
    public List<Pos> posList = new List<Pos>();
    public float delayesecond = 3f;
    private GameObject A;
    private GameObject B;
    public GameObject C;
    public string[] messages = new string[] { "Tips : Card is omnipotent", "Tips : We don't charge, but we want you to donate", "Tips : If you win the game , please realize you are still alone" ,"Tips : Poor Tarnished, why you undertake this impossible dream ?"};
    // public TextMeshProUGUI hintText;
    void Awake()
    {   
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
     //   LoadingCanvas = GameObject.Find("Canvas1");
      //  for (int i = 0; i < LoadingCanvas.transform.childCount; i++)
      //  {
          //  Transform parent = LoadingCanvas.transform;
          //  Pos temp = new Pos();
          //  temp.a = parent;
          //  temp.name = parent.name;
         //   posList.Add(temp);
       // }
     //   LoadingScreen = GameObject.Find("Grid");
      // A = LoadingCanvas;
      //  B = LoadingScreen;
  //      for (int i = 0; i < LoadingScreen.transform.childCount; i++)
        //{
         //   Transform parent1 = LoadingScreen.transform;
         //   Pos temp1 = new Pos();
         //   temp1.a = parent1;
         //   temp1.name = parent1.name;
          //  posList.Add(temp1);
        //

    }
    public void Update()
    {
        int randomNumber = Random.Range(0, 5);
        if(Input.GetMouseButtonDown(0) && (SceneManager.GetActiveScene().name == "loadingscene" || SceneManager.GetActiveScene().name == "coverscene")) 
        {
            Vector3 clickPosition = Input.mousePosition; clickPosition.z = 100f;
            Debug.Log("ÂIÀ»¤F·Æ¹«¡I");
            clickPosition.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            Vector3 c = worldPosition; 
            c.z = 100f;
            worldPosition.z = 0f;
            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
            Instantiate(C, c, rotation);
            if( A != null) 
            {
                A.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = messages[Random.Range(0, 4)];
            }
            //   Judge(hit);
        }
    }
    public void LoadScene(int sceneId)
    {

        StartCoroutine(LoadLoadingSceneThenScene(sceneId));
        //  while (SceneManager.GetActiveScene().name != "loadingscene") ;

        //  B = Instantiate(LoadingScreen, posList[0].a.position, Quaternion.identity);
        //    A = Instantiate(LoadingCanvas, posList[1].a.position, Quaternion.identity);


        //  Transform child = LoadingCanvas.transform.GetChild(5); 
        //  GameObject childObj = child.gameObject;
       // StartCoroutine(LoadSceneAsync(sceneId,delayesecond,A,B));
    }
    IEnumerator LoadLoadingSceneThenScene(int sceneId)
    {
       
        AsyncOperation loadLoading = SceneManager.LoadSceneAsync("loadingscene");
        while (!loadLoading.isDone)
        {   

            yield return null;
        }

      
       // LoadingCanvas = GameObject.Find("Canvas1");
      //  LoadingScreen = GameObject.Find("Grid");

        A = Instantiate(LoadingCanvas1, LoadingCanvas1.transform.position, Quaternion.identity);
        B = Instantiate(LoadingScreen1, LoadingScreen1.transform.position, Quaternion.identity);
        Transform child = A.transform.GetChild(2);  
        TextMeshProUGUI tmp = child.GetComponent<TextMeshProUGUI>();
        tmp.text = messages[Random.Range(0,4)];
       
        yield return StartCoroutine(LoadSceneAsync(sceneId, delayesecond, A, B));
    }
    IEnumerator LoadSceneAsync(int sceneId,float delaysecond,GameObject a,GameObject b)
    {
        float t = 0f;
        Transform secdChild = a.transform.GetChild(1);

        
        GameObject secChildObj = secdChild.gameObject;

        while (t < delaysecond)
        {
            t += Time.deltaTime;
            secChildObj.GetComponent<Image>().fillAmount = Mathf.Clamp01(t /  (2 * delaysecond));
            yield return null;
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

      //  LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f) * 0.5f + 0.5f;
            secChildObj.GetComponent<Image>().fillAmount = progressValue;
            yield return null;
        }
    }
    public void Changetext()
    {

    }

}
public class Pos {
    public Transform a;
    public string name;
}
