using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class inventoryUIManager : MonoBehaviour
{
    public static inventoryUIManager instance;

    [Header("UI 元件")]
    public GameObject inventoryPanel;         // 整個顯示面板
    public Transform weaponContainer;         // 放武器 UI 項目的容器
    public Transform buffContainer;           // 放 Buff UI 項目的容器
    public GameObject itemPrefab;             // 顯示單個項目的預製物件（含圖示與文字）

    private void Awake()
    {
        instance = this;
        inventoryPanel.SetActive(false); // 一開始隱藏面板
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab");
            inventoryPanel.SetActive(true);

            // 取得玩家持有資料並更新 UI
            UpdateInventoryUI(
                playerInventory.instance.ownedWeapons.ToArray(),
                playerInventory.instance.ownedBuffs.ToArray()
            );
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void UpdateInventoryUI(WeaponData[] weapons, UpgradeData[] buffs)
    {
        ClearChildren(weaponContainer);
        ClearChildren(buffContainer);

        foreach (var weapon in weapons)
        {
           // CreateItemUI(weaponContainer, weapon.icon, weapon.weaponName);
        }

        foreach (var buff in buffs)
        {
            CreateItemUI(buffContainer, buff.icon, buff.upgradeName);
        }
    }

    private void CreateItemUI(Transform parent, Sprite icon, string name)
    {
        GameObject go = Instantiate(itemPrefab, parent);
        go.GetComponentInChildren<Image>().sprite = icon;
        go.GetComponentInChildren<TextMeshProUGUI>().text = name;
    }

    private void ClearChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
