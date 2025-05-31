using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Collections;

public class SpawnEffectOnClick : MonoBehaviour
{
    public GameObject effectPrefab;  

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 clickPosition = Input.mousePosition;
            clickPosition.z = 100f;
       //     Debug.Log("ÂIÀ»¤F·Æ¹«¡I");

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
           Instantiate(effectPrefab, worldPosition, rotation);

        }
    }
    


}
