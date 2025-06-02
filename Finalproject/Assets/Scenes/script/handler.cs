using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject LoadingCanvas;
   // public TextMeshProUGUI hintText;
    public void LoadScene(int sceneId)
    {
        Transform child = LoadingCanvas.transform.GetChild(2); 
        GameObject childObj = child.gameObject;
        StartCoroutine(LoadSceneAsync(sceneId,childObj));
    }

    IEnumerator LoadSceneAsync(int sceneId,GameObject child)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);
        LoadingCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            child.GetComponentInChildren<Image>().fillAmount = progressValue;
            yield return null;
        }
    }
}