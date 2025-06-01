using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
//using UnityEngine.Events;
public class SpawnEffectOnClick : MonoBehaviour
{
    public UnityEvent buttonevent;
    public GameObject effectPrefab;
    public GameObject showcase;
    public GameObject canvas;
   // public player a;
    private void Awake()
    {
        buttonevent.AddListener(canvas.GetComponent<SceneSwitcher>().DeactivateAllChildren);
        buttonevent.AddListener(showcase.GetComponent<CharacterShowcase>().Release);
    }
   
    // public GameObject model;
    public int count = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Input.mousePosition; clickPosition.z = 100f;
            Debug.Log("ÂIÀ»¤F·Æ¹«¡I");
            clickPosition.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
            Vector3 c = worldPosition; c.z = 100f;
            worldPosition.z = 0f;
            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
            Instantiate(effectPrefab, c, rotation);
        //    Collider2D hit = Physics2D.OverlapPoint(worldPosition);
         //   Judge(hit);
        }


    }
    public void Buttonfunc()
    {
        buttonevent.Invoke();
    }


}
