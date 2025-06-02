using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class SceneSwitcher : MonoBehaviour
{
    private int index;
    public GameObject a;
    public void DeactivateAllChildren()
    {
        if (a.GetComponent<CharacterShowcase>().currentIndex == 0)
        {
            for (int i = 0; i < transform.childCount - 2; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        
    }
}

