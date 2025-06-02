using UnityEngine;
using System.Collections.Generic;

public class playerInventory : MonoBehaviour
{
    public static playerInventory instance;

    public List<WeaponData> ownedWeapons = new List<WeaponData>();
    public List<UpgradeData> ownedBuffs = new List<UpgradeData>();

    private void Awake()
    {
        instance = this;
    }

    public void addWeapon(WeaponData data)
    {
        if (!ownedWeapons.Contains(data))
            ownedWeapons.Add(data);
    }

    public void addBuff(UpgradeData data)
    {
        if (!ownedBuffs.Contains(data))
            ownedBuffs.Add(data);
    }
}
