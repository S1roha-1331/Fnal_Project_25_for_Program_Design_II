using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Collections;
using System.Collections.Generic;
public class SpawnEffectOnClick : MonoBehaviour
{
    public GameObject effectPrefab;
    public GameObject showcase;
   // public GameObject model;
    public int count = 0;
    void Update()
    {

       
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;

                Debug.Log($"檢測座標: {mouseWorldPos}");

                // 使用小範圍的圓形檢測，而不是精確點檢測
                Collider2D hit = Physics2D.OverlapCircle(mouseWorldPos, 0.1f);

                if (hit != null)
                {
                    Debug.Log($"成功檢測到: {hit.name}");
                    Judge(hit);
                }
                else
                {
                    Debug.Log("OverlapCircle 也沒檢測到");
                }
            }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Input.mousePosition;      clickPosition.z = 100f;  
            Debug.Log("點擊了滑鼠！");    
            clickPosition.z = -Camera.main.transform.position.z;     
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);  
            Vector3 c = worldPosition;     c.z = 100f;   
            worldPosition.z = 0f;    
            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);  
            Instantiate(effectPrefab, c, rotation);    
            Collider2D hit = Physics2D.OverlapPoint(worldPosition);      
            Judge(hit); 
        }


        }
    
    void Judge( Collider2D hit)
    {
       // Debug.Log("Judge function called");
        if (hit != null)
        {    Debug.Log("Hit: " + hit.name); 
            Debug.Log("Judge function called");
            for (int i = 0; i < showcase.GetComponent<CharacterShowcase>().database.Count; i++) 
            {
                if(hit.gameObject == showcase.GetComponent<CharacterShowcase>().database[i].a)
                {
                    if (showcase.GetComponent<CharacterShowcase>().database[i].locker != 0)
                    {
                        //showcase.GetComponent<CharacterShowcase>().database[i].a.GetComponent<Rigidbody2D>(). = false;
                        showcase.GetComponent<CharacterShowcase>().database[i].a.GetComponent<Rigidbody2D>().simulated = true; 

                        return;

                    }
                   
                }
            }
        }
    }

}
