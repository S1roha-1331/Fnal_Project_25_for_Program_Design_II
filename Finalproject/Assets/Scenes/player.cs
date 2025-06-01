using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         Debug.Log($"物件 {gameObject.name} 狀態:");
    Debug.Log($"- GameObject 啟用: {gameObject.activeInHierarchy}");
    Debug.Log($"- 位置: {transform.position}");
    Debug.Log($"- Layer: {gameObject.layer} ({LayerMask.LayerToName(gameObject.layer)})");
    
    Collider2D col = GetComponent<Collider2D>();
    if (col != null)
    {
        Debug.Log($"- Collider2D 啟用: {col.enabled}");
        Debug.Log($"- IsTrigger: {col.isTrigger}");
        Debug.Log($"- Bounds: {col.bounds}");
    }
    else
    {
        Debug.Log("- 沒有 Collider2D 組件!");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
