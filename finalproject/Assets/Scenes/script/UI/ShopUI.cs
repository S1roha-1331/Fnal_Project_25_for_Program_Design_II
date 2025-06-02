using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contentArea;
    public List<ShopItemData> items;
    public TextMeshProUGUI insufficientText;

    void Start()
    {
        PopulateShop();
        insufficientText.gameObject.SetActive(false);
    }

    void PopulateShop()
    {
        foreach (var item in items)
        {
            GameObject obj = Instantiate(itemPrefab, contentArea);
            obj.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
            obj.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = item.itemName;
            obj.transform.Find("PriceText").GetComponent<TextMeshProUGUI>().text = item.price.ToString();

            obj.transform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(() =>
            {
                TryBuy(item);
            });
        }
    }

    void TryBuy(ShopItemData item)
    {
        if (InventoryManager.Instance.SpendCoins(item.price))
        {
            Debug.Log("已購買：" + item.itemName);
            ApplyStatUpgrade(item.targetStat, item.amount);
            insufficientText.text = "";
        }
        else
        {
            Debug.Log("金幣不足");
            StartCoroutine(ShowInsufficientMessage());
        }
    }
    void ApplyStatUpgrade(StatType stat, float amount)
    {
        var stats = playerStats.instance;
        if (stats == null)
        {
            Debug.LogWarning("找不到 playerStats 實例");
            return;
        }

        switch (stat)
        {
            case StatType.Attack:
                stats.basicAttack += amount;
                break;
            case StatType.Speed:
                stats.playerController.basicSpeed += amount;
                stats.playerController.finalSpeed = stats.playerController.basicSpeed;
                break;
            case StatType.Health:
                stats.basicHealth += amount;
                stats.playerHealth.maxHp = stats.MaxHealth;
                stats.playerHealth.currentHp = stats.playerHealth.maxHp;
                break;
        }

        Debug.Log($"[永久升級] {stat} +{amount}");
    }

    IEnumerator ShowInsufficientMessage()
    {
        insufficientText.gameObject.SetActive(true); 
        insufficientText.text = "Come back when your wallet's heavier... or your morals lighter.";
        insufficientText.alpha = 1;
        yield return new WaitForSeconds(2f);
        insufficientText.gameObject.SetActive(false); 
    }
}
