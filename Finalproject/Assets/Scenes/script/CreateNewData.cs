using UnityEngine;
using System.Collections;
using System;
//using UnityEditor.Overlays;

public class CreateNewData : MonoBehaviour
{

    private Savedata savedata;
    [SerializeField]
    //private GameObject obj;

    void Start()
    {
        savedata = new Savedata();

        savedata.SetCoin(0);
    }

    public Savedata GetSaveData()
    {
        return savedata;
    }
}
