using UnityEngine;
using System.Collections;
using System;
using System.Numerics;

[System.Serializable]
public class Savedata : object
{
    public int coin;
    
    public void SetCoin(int coin)
    {
        this.coin = coin;
    }
    public int GetCoin()
    {
        return this.coin;
    }

    public string GetNormalData()
    {
        return "coin: " + coin;
    }
}
