using TMPro;
using UnityEngine;

public class CoinUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    InventoryManager inventoryManager;

    private int lastCoins = -1; // 初始值設為不可能的金幣數，確保第一次會更新

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    void Update()
    {
        int currentCoins = inventoryManager.coins;
        if (currentCoins != lastCoins)
        {
            lastCoins = currentCoins;
            coinText.text = currentCoins.ToString();
        }
    }
}
