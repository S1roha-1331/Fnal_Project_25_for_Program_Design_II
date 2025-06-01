using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class CoinUIUpdater : MonoBehaviour
{
    public TextMeshProUGUI coinText; 

    void Start()
    {
        coinText.text = iventoryManager.instance.coins.ToString();
    }

    void Update()
    {
        coinText.text = iventoryManager.instance.coins.ToString();
    }
}
