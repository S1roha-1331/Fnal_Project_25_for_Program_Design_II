using UnityEngine;
using TMPro;

public class ResultUIManager : MonoBehaviour
{
    public static ResultUIManager instance;
    public GameObject resultPanel;
    public TextMeshProUGUI coinText;
    public InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        instance = this;
        resultPanel.SetActive(false); 
    }

    public void showResult()
    {
        resultPanel.SetActive(true);
        Time.timeScale = 0f;
        int coinAmount = inventoryManager.coins;
        coinText.text=coinAmount.ToString();
    }
    public void quitGame()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
