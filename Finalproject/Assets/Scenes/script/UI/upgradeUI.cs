using System.Collections.Generic;
using UnityEngine;

public class upgradeUI : MonoBehaviour
{
    public static upgradeUI instance;
    public GameObject panel;
    public upgradeButtonUI[] optionButtons;
    public List<UpgradeData> allUpgrades;

    void Awake()
    {
        instance = this;
    }

    public void ShowUpgradeOptions()
    {
        panel.SetActive(true);

        // �H���D 3 �Ӥɯ�
        List<UpgradeData> selected = new List<UpgradeData>();
        while (selected.Count < 3)
        {
            UpgradeData randomUpgrade = allUpgrades[Random.Range(0, allUpgrades.Count)];
            if (!selected.Contains(randomUpgrade))
                selected.Add(randomUpgrade);
        }

        // �]�w�C�ӫ��s�����
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].Setup(selected[i]);
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}

