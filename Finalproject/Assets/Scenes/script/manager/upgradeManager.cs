using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 保證只有一個
            return;
        }
        instance = this;
    }

    public void applyUpgrade(UpgradeData data)
    {
        if (data.upgradeKind == 1)
        {
            playerInventory.instance.addBuff(data);
        }
        else if(data.upgradeKind == 2)
        {
            //playerInventory.instance.addWeapon(data);
        }
        switch (data.effectType)
        {
            case UpgradeEffectType.PowerInfusionI:
                playerStats.instance.increaseAttackI();
                break;
            case UpgradeEffectType.PowerInfusionII:
                playerStats.instance.increaseAttackII();
                break;
            case UpgradeEffectType.PowerInfusionIII:
                playerStats.instance.increaseAttackIII();
                break;
            case UpgradeEffectType.SwiftCoreI:
                playerStats.instance.increaseSpeedI();
                break;
            case UpgradeEffectType.SwiftCoreII:
                playerStats.instance.increaseSpeedII();
                break;
            case UpgradeEffectType.SwiftCoreIII:
                playerStats.instance.increaseSpeedIII();
                break;
            case UpgradeEffectType.VitalEssenceI:
                playerStats.instance.increaseHealthI();
                break;
            case UpgradeEffectType.VitalEssenceII:
                playerStats.instance.increaseHealthII();
                break;
            case UpgradeEffectType.VitalEssenceIII:
                playerStats.instance.increaseHealthIII();
                break;
            default:
               
                break;
        }

    }
}
