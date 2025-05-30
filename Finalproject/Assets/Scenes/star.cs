using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class star : MonoBehaviour
{
    public GameObject starspawner;
    public GameObject effect;
    private float timer = 0;
    public float offsetx = 0, offsety = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        starspawner = GameObject.FindWithTag("starspawnertag");
        effect = Instantiate(effect, gameObject.transform.position +new Vector3(offsetx,offsety,0), Quaternion.identity);
       // effect.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 20)
        {   
            starspawner.GetComponent<StarSpawner>().count--;
            StartCoroutine(StopAndDestroyEffect());
        
          
          
                   }
    }
    private IEnumerator StopAndDestroyEffect()
    {
        var ps = effect.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Stop(); 

         
            float maxLifetime = ps.main.startLifetime.constantMax;
            yield return new WaitForSeconds(maxLifetime);
        }

     
        Destroy(gameObject);
        Destroy(effect);
    }
}
