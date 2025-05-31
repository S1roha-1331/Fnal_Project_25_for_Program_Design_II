using UnityEngine;
using TMPro;
using DG.Tweening; // �ޤJ DOTween �R�W�Ŷ�

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

        // ? �X�{�ɨϥμu�X�Y��ʵe�]��j�A�Y�^�^
        transform.localScale = Vector3.zero;

        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(Vector3.one * 1.3f, 0.25f).SetEase(Ease.OutQuad)); // ��j
        s.Append(transform.DOScale(Vector3.one, 0.15f).SetEase(Ease.InQuad));         // �Y�^
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
