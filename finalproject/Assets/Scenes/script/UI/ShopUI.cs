using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contentArea;
    public List<ShopItemData> items; 

    void Start()
    {
        PopulateShop();
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
        }
        else
        {
            Debug.Log("金幣不足！");
        }
    }
}
