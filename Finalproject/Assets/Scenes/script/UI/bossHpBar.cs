using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class bossHpBar : MonoBehaviour
{
    [SerializeField] private Image healthfill;
    [SerializeField] private TextMeshProUGUI bossName;

    private float maxHealth;
    private float currentHealth;

    public void setBossName(string name)
    {
        bossName.text = name;
    }
    public void setMaxHealth(float health)
    {
        maxHealth = health;
       updateHealthBar();
    }

    public void setCurrentHealth(float health)
    {
        currentHealth = health;
        updateHealthBar();
    }

    public void updateHealthBar()
    {
        if (maxHealth <= 0)
        {
            healthfill.fillAmount = 0;
            return;
        }
        else
        {
            healthfill.fillAmount = currentHealth/maxHealth;
        }
    }
}
