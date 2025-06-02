using UnityEngine;

public enum StatType
{
    Attack,
    Speed,
    Health
}

[CreateAssetMenu(menuName = "Shop/ShopItemData")]
public class ShopItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;

    public StatType targetStat;  // 升級目標
    public float amount;         // 增加數值
}
