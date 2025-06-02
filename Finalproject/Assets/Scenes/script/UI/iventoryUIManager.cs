using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class inventoryUIManager : MonoBehaviour
{
    public static inventoryUIManager instance;

    [Header("UI ����")]
    public GameObject inventoryPanel;         // �����ܭ��O
    public Transform weaponContainer;         // ��Z�� UI ���ت��e��
    public Transform buffContainer;           // �� Buff UI ���ت��e��
    public GameObject itemPrefab;             // ��ܳ�Ӷ��ت��w�s����]�t�ϥܻP��r�^

    private void Awake()
    {
        instance = this;
        inventoryPanel.SetActive(false); // �@�}�l���í��O
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("tab");
            inventoryPanel.SetActive(true);

            // ���o���a������ƨç�s UI
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
