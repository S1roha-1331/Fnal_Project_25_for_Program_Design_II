using UnityEngine;
using System.Collections;
public class Lock : MonoBehaviour
{
    public float rotationSpeed = 320f;
    //  public float rotationSpeed = 180f;
    public bool isrotating = false;
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
        if (gameObject.activeSelf && isrotating == false) {
            StartCoroutine(round());
        }
    }
    IEnumerator round()

    {
        isrotating = true;
        float t = 0f;
        while (t < 0.8f) {
            if (t < 0.2f || t > 0.6f)
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
        isrotating = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f); 

    }
    public void settrue()
    {
       gameObject.SetActive(true);
    }
    public void setfalse()
    {
        gameObject.SetActive(false);
    }
}
