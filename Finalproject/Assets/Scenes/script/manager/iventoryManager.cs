using UnityEngine;

public class iventoryManager : MonoBehaviour
{
   public static iventoryManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int coins = 0;
    public void addCoins(int amount)
    {
        coins+=amount;
    }
}
