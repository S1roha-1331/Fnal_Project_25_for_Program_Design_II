using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrades/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;           
    [TextArea]
    public string description;            
    public Sprite icon;
    public Sprite background;
    public UpgradeEffectType effectType;
    public int upgradeKind;//1 for buff //2 for weapon
}
public enum UpgradeEffectType
{
    PowerInfusionI,
    PowerInfusionII,
    PowerInfusionIII,
    SwiftCoreI,
    SwiftCoreII,
    SwiftCoreIII,
    VitalEssenceI,
    VitalEssenceII,
    VitalEssenceIII,
}

