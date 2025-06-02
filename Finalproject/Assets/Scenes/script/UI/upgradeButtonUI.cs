using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class upgradeButtonUI : MonoBehaviour
{
    public Image iconImage;                  // UI �W���ϥ�
    public TextMeshProUGUI nameText;         // �W�٤�r
    public TextMeshProUGUI descriptionText;  // �y�z��r
    public Image background;
    private UpgradeData upgradeData;         // �x�s������ ScriptableObject

    // �Ψӳ]�w UI ���
    public void Setup(UpgradeData data)
    {
        upgradeData = data;
        background.sprite=data.background;
        iconImage.sprite = data.icon;
        nameText.text = data.upgradeName;
        descriptionText.text = data.description;
    }

    // �I�U���s�ɥs��
    public void OnClick()
    {
        UpgradeManager.instance.applyUpgrade(upgradeData);
        upgradeUI.instance.Hide();
        Time.timeScale = 1f;
    }
    
}
