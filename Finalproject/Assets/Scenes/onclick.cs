using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
   public void LoadNextScene()
    {
      
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

      
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
