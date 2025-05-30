using UnityEngine;

public class SpawnEffectOnClick : MonoBehaviour
{
    public GameObject effectPrefab;  

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 clickPosition = Input.mousePosition;
            clickPosition.z = 10f;  

           
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
            Instantiate(effectPrefab, worldPosition, rotation);
        }
    }
}
