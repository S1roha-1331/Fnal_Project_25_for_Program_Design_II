using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Debug.Log($"���� {gameObject.name} ���A:");
    Debug.Log($"- GameObject �ҥ�: {gameObject.activeInHierarchy}");
    Debug.Log($"- ��m: {transform.position}");
    Debug.Log($"- Layer: {gameObject.layer} ({LayerMask.LayerToName(gameObject.layer)})");
    
    Collider2D col = GetComponent<Collider2D>();
    if (col != null)
    {
        Debug.Log($"- Collider2D �ҥ�: {col.enabled}");
        Debug.Log($"- IsTrigger: {col.isTrigger}");
        Debug.Log($"- Bounds: {col.bounds}");
    }
    else
    {
        Debug.Log("- �S�� Collider2D �ե�!");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
