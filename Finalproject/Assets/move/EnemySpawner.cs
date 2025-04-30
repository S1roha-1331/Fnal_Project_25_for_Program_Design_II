using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;         // 敵人預製物件（從這個複製產生）
    public float startInterval = 5f;       // 初始生成間隔時間（秒）
    public float minInterval = 1f;       // 最快生成間隔下限
    public float decreaseRate = 0.05f;     // 每次生成後減少多少間隔時間

    private float currentInterval;         // 當前間隔時間（會一直變小）
    private float timer;                   // 計時器

    void Start()
    {
        currentInterval = startInterval;   // 一開始使用初始間隔
        timer = currentInterval;           // 初始化倒數計時器
    }

    void Update()
    {
        timer -= Time.deltaTime;           // 每幀倒數

        if (timer <= 0f)
        {
            SpawnEnemy();                  // 時間到 → 產生敵人
            currentInterval = Mathf.Max(minInterval, currentInterval - decreaseRate);  
            // 每次產生完，減少間隔時間（不低於 minInterval）
            timer = currentInterval;       // 重設倒數計時器
        }
    }

    void SpawnEnemy()
    {
        // 產生位置：在本體附近圓形範圍外圍，距離 10 單位
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * 10f;

        // 複製敵人，放到指定位置
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
