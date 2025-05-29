using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hpBar : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]private playerHealth playerHealth;

    [Header("Interface")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image healthFill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
   
    void Update()
    {
        UPdateHealthUI();
    }
    void UPdateHealthUI()
    {
        if (playerHealth == null)
        {
            return;
        }
        float current = playerHealth.currentHp;
        float max = playerHealth.maxHp;

        healthText.text = current + " / " + max;
        healthFill.fillAmount = (float)current / max;
    }
}

