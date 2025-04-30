using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform target;          // 跟著誰動（通常是玩家）
    public float scrollSpeed = 0.1f;  // 滑動速度因子

    private Material mat;
    private Vector2 offset;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        offset = mat.mainTextureOffset;
    }

    void Update()
    {
        Vector2 movement = target.position * scrollSpeed;
        mat.mainTextureOffset = offset + movement;
    }
}
