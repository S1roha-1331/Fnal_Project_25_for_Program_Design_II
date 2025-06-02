
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneHandler : MonoBehaviour
{

    public static SceneHandler Instance;
    public float duration = 1f;

    public Image progressBar;
    public TextMeshProUGUI hintText;
    public GameObject canvas;
    private AsyncOperation loadingOperation;
    private bool readyToActivate = false;
    public int currentSceneIndex;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Loading()
    {
        //  currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.sceneLoaded += OnLoadingSceneLoaded;
        SceneManager.LoadScene("loadingscene");
    }

    private void OnLoadingSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "loadingscene")
        {
            canvas = GameObject.Find("Canvas");
            progressBar = canvas.transform.Find("loadbar").GetComponent<Image>();
            hintText = canvas.transform.Find("123").GetComponent<TextMeshProUGUI>();
            hintText.text = "Loading...";
            SceneManager.sceneLoaded -= OnLoadingSceneLoaded;

            StartCoroutine(BeginLoad("coverscene"));
        }
    }

    IEnumerator BeginLoad(string sceneName)
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingOperation.allowSceneActivation = false;

        while (!loadingOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            progressBar.fillAmount = progress;
            yield return null;
        }

        progressBar.fillAmount = 1f;
        hintText.text = "Press any key to continue...";
        //  Destroy(canvas);
        readyToActivate = true;
    }

    void Update()
    {
        if (readyToActivate && Input.anyKeyDown)
        {
            loadingOperation.allowSceneActivation = true;
        }
    }
}
