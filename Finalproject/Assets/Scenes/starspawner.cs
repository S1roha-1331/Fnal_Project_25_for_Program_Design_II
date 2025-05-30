using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject[] star;
    public int count = 0;
    private float timer = 0;
    void Start()
    {
       // SpawnStars();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1 && Random.Range(0, 2) == 1 && count <= 20)
        {
            SpawnStars();
            timer = 0;
        }
    }
    void SpawnStars()
    {
        
            Vector3 spawnPos = new Vector3(
                Random.Range(-20f, 20f),
                Random.Range(0f, 20f),
             0f
            );

        int randomIndex = Random.Range(0, star.Length);
      GameObject starinstance = Instantiate(star[randomIndex], spawnPos, Quaternion.identity);
        if(randomIndex == 4)
        {
            star script = starinstance.GetComponent<star>();
            script.offsetx = -0.2f;
           script.offsety = -0.34f;
        }
        count++;
    }
}
