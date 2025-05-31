using UnityEngine;
using TMPro;
using DG.Tweening; // 引入 DOTween 命名空間

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;

    private float floatSpeed = 1f;
    private float disappearTime = 1f;
    private Color textColor;

    public void Setup(float damageAmount)
    {
        textMesh.text = damageAmount.ToString();
        textColor = textMesh.color;

        // ? 出現時使用彈出縮放動畫（放大再縮回）
        transform.localScale = Vector3.zero;

        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(Vector3.one * 1.3f, 0.25f).SetEase(Ease.OutQuad)); // 放大
        s.Append(transform.DOScale(Vector3.one, 0.15f).SetEase(Ease.InQuad));         // 縮回
    }

    private void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        disappearTime -= Time.deltaTime;
        if (disappearTime <= 0f)
        {
            textColor.a -= 2f * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a <= 0)
                Destroy(gameObject);
        }
    }
}
