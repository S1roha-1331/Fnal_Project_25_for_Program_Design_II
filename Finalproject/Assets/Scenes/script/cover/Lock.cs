using UnityEngine;
using System.Collections;
public class Lock : MonoBehaviour
{
    public float rotationSpeed = 5000f;
  //  public float rotationSpeed = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotation()
    {
        Debug.Log("calling");
        StartCoroutine(round());
    }
    IEnumerator round()
    { float t = 0f;
        while (t < 2) {
            if (t < 1)
            {
                transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
                t += Time.deltaTime;
                yield return null;
            }
            else
            {
                transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
                t += Time.deltaTime;
                yield return null;
            }

        }
    }
}
