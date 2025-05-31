using UnityEngine;
using System.Collections;
public class starburst : MonoBehaviour
{   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
      
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        foreach (var k in GetComponentsInChildren<ParticleSystem>())
        {
            k.Play();
        }

        StartCoroutine(PlayAndDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PlayAndDestroy()
    {
        float maxLifetime = 0f;
        foreach (var ps in GetComponentsInChildren<ParticleSystem>())
        {
            float duration = ps.main.duration + ps.main.startLifetime.constantMax;
            if (duration > maxLifetime)
                maxLifetime = duration;
        }
        yield return new WaitForSeconds(maxLifetime);
        Destroy(gameObject);
       // Destroy();
    }
}
