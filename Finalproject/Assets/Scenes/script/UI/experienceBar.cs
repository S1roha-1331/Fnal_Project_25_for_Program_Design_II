using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;
    int previousLevelsExperience, nextLevelsExperience;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceFill;

    [SerializeField] playerStats playerStats;
    [SerializeField] playerHealth playerHealth;

    void Start()
    {
        StartCoroutine(DelayedLevelUpdate());
    }

    IEnumerator DelayedLevelUpdate()
    {
        yield return null; // ���ݤ@�V
        currentLevel = 1;
        totalExperience = (int)experienceCurve.Evaluate(currentLevel);
        UpdateLevel();
    }

    void Update()
    {
       
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if (totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            upgradeUI.instance.ShowUpgradeOptions();
            UpdateLevel();
            // �i�H�[�ʵe�B���ĩίS��
        }
    }

    void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);

        if (playerStats != null)
        {
            playerStats.Level = currentLevel;
        }

        if (playerHealth != null)
        {
            playerHealth.OnLevelUp(); // �^���嵥�޿�
        }
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + " exp / " + end + " exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }
}
