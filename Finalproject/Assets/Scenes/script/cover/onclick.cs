using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    
    public void DeactivateAllChildren()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}

