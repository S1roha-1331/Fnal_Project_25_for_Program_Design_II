using UnityEngine;

public class weaponOrder : MonoBehaviour
{
    //the tag of the latest added extra weapon
    public int latestWeapon;

    public int weaponLimit = 5;//the amount of extra weapon cannot above 6

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        latestWeapon = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
