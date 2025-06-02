using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransfer : MonoBehaviour
{
    [SerializeField] private string targetSceneName; // 要切換到的場景名稱
    public GameObject handler;
    private void Start()
    {
        Debug.Log("✅ MapTransfer.cs 啟動成功！");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("⚠️ 進入觸發器的是：" + other.name);
        Debug.Log("🔍 它的 Tag 是：" + other.tag); // ← 重點在這行！

        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player 觸發成功！");
            // SceneManager.LoadScene(targetSceneName);
            handler = GameObject.FindGameObjectWithTag("scenehandler");
            handler.GetComponent<LoadingScene>().LoadScene(3);
        }

    }
}
