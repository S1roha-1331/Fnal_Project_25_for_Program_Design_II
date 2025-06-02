using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor.Overlays;
using UnityEngine.InputSystem.Processors;
using System.Text;
using System.IO.Pipes;


public class SaveLoad : MonoBehaviour
{
    public playerStats stats;
    private GameObject self;
    private CreateNewData create;
    public InventoryManager inventoryManager;

    private string filePath;
    private string coinS;
    private int coinI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<playerStats>();
        self = GetComponentInParent<Transform>().gameObject;
        create = GetComponent<CreateNewData>();
        inventoryManager = FindAnyObjectByType<InventoryManager>();

        filePath = Application.dataPath + @"\Save" ;
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        filePath = filePath + @"\savedata.dat";
        if (!File.Exists(filePath))
        {
            using (File.Create(filePath))
            {
            }
            //create.GetSaveData().SetCoin(coinI);
            coinI = inventoryManager.coins;
            coinS = coinI.ToString();
            File.WriteAllText(filePath, coinS);
        }
        else
        {
            load();
        }

        int[] dat = new int[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.playerHealth.isDead)
        {
            save();
        }
    }

    public void save()
    {
        coinS = inventoryManager.coins.ToString();
        File.WriteAllText(filePath, coinS);
        Debug.Log("save: " + coinS);
        Destroy(self);
    }

    public void load()
    {
        coinS = File.ReadAllText(filePath);
        Debug.Log("load: " + coinS);
        coinI = int.Parse(coinS);
    }


    public void saveAll()
    {
        
        string[] datas = new string[3];

        //File.Delete(filePath);using (File.Create(filePath)){}
        File.WriteAllLines(filePath, datas);
    }

    public void loadAll()
    {
        //filePath = Application.dataPath + @"\Save\savedata.dat";

        using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
        {
            while (!streamReader.EndOfStream)
            {
                int d = int.Parse(streamReader.ReadLine());
                Debug.Log("Loading by stream: " + streamReader.ReadLine());
            }
        }
    }
}
