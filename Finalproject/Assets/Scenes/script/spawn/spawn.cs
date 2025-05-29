using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemyPrefab;         // �ĤH�w�s����]�q�o�ӽƻs���͡^
    public float startInterval = 5f;       // ��l�ͦ����j�ɶ��]��^
    public float minInterval = 1f;       // �̧֥ͦ����j�U��
    public float decreaseRate = 0.05f;     // �C���ͦ����֦h�ֶ��j�ɶ�
    public GameObject player;

    private float currentInterval;         // ��e���j�ɶ��]�|�@���ܤp�^
    private float timer;                   // �p�ɾ�

    void Start()
    {
        currentInterval = startInterval;   // �@�}�l�ϥΪ�l���j
        timer = currentInterval;           // ��l�ƭ˼ƭp�ɾ�
    }

    void Update()
    {
        timer -= Time.deltaTime;           // �C�V�˼�

        if (timer <= 0f)
        {
            SpawnEnemy();                  // �ɶ��� �� ���ͼĤH
            currentInterval = Mathf.Max(minInterval, currentInterval - decreaseRate);
            // �C�����ͧ��A��ֶ��j�ɶ��]���C�� minInterval�^
            timer = currentInterval;       // ���]�˼ƭp�ɾ�
        }
    }

    void SpawnEnemy()
    {
        // ���ͦ�m�G�b��������νd��~��A�Z�� 10 ���
        Vector2 spawnPos = (Vector2)player.transform.position + Random.insideUnitCircle.normalized * 10f;

        // �ƻs�ĤH�A�����w��m
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}