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
        yield return null; // 等待一幀
        currentLevel = 1;
        totalExperience = (int)experienceCurve.Evaluate(currentLevel);
        UpdateLevel();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddExperience(5);
        }
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
            // 可以加動畫、音效或特效
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
            playerHealth.OnLevelUp(); // 回滿血等邏輯
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
