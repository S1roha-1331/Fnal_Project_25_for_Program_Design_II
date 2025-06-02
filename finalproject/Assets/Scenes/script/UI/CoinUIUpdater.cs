using TMPro;
using UnityEngine;

public class CoinUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private int lastCoins = -1; // 初始值設為不可能的金幣數，確保第一次會更新

    void Update()
    {
        int currentCoins = InventoryManager.Instance.coins;
        if (currentCoins != lastCoins)
        {
            lastCoins = currentCoins;
            coinText.text = currentCoins.ToString();
        }
    }
}
