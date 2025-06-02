using System.Collections.Generic;
using UnityEngine;
public class WeaponDatabase : MonoBehaviour
{
    [SerializeField] private WeaponData[] allWeapons;
    private Dictionary<int, WeaponData> weaponLookup;

    private void Awake()
    {
        // Create lookup dictionary for fast access
        weaponLookup = new Dictionary<int, WeaponData>();
        foreach (WeaponData weapon in allWeapons)
        {
            weaponLookup[weapon.weaponID] = weapon;
        }
    }

    public WeaponData GetWeaponByID(int weaponID)
    {
        return weaponLookup.TryGetValue(weaponID, out WeaponData data) ? data : null;
    }

    public WeaponData[] GetAllWeapons()
    {
        return allWeapons;
    }
}

