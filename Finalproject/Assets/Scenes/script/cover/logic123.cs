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
    public GameObject locker;
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
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; 

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            float distance = Vector2.Distance(new Vector2(locker.transform.position.x, locker.transform.position.y),
                                          new Vector2(worldPos.x, worldPos.y));

            if (distance < 20f)
            {
                locker.GetComponent<Lock>().Rotation();
            }
        }


    }
    public void Buttonfunc()
    {
        buttonevent.Invoke();
    }


}
