using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgradeButtonUI : MonoBehaviour
{
    public Image iconImage;                  // UI 上的圖示
    public TextMeshProUGUI nameText;         // 名稱文字
    public TextMeshProUGUI descriptionText;  // 描述文字
    public Image background;
    private UpgradeData upgradeData;         // 儲存對應的 ScriptableObject

    // 用來設定 UI 顯示
    public void Setup(UpgradeData data)
    {
        upgradeData = data;
        background.sprite=data.background;
        iconImage.sprite = data.icon;
        nameText.text = data.upgradeName;
        descriptionText.text = data.description;
    }

    // 點下按鈕時叫用
    public void OnClick()
    {
        UpgradeManager.instance.applyUpgrade(upgradeData);
        upgradeUI.instance.Hide();
        Time.timeScale = 1f;
    }
    
}
