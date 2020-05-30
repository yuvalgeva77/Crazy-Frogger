using Random = UnityEngine.Random;
using UnityEngine;

public class birdSpawner : MonoBehaviour
{
    public GameObject bird, egg;
    public Transform[] SpwanPoints;
    public float countDownSpawnTimer = 3f;
    public float countEggpawnTimer = 7f;
    int[] laneCounter;
    int numSpawns = 0;
    // Start is called before the first frame update
    void Start()
    {
        laneCounter = new int[SpwanPoints.Length];
        for (int i = 0; i < SpwanPoints.Length; i++)
        {
            laneCounter[i] = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownSpawnTimer <= 0f)
        {
            SpawnBird();
            countDownSpawnTimer = 3f;
        }
        else
        {
            countDownSpawnTimer -= Time.deltaTime;
        }

        if (countDownSpawnTimer <= 0f)
        {
            SpawnEgg();
            countEggpawnTimer = 7f;
        }
        else
        {
            countDownSpawnTimer -= Time.deltaTime;
        }
    }

    void SpawnBird()
    {
        int randomIndex = Random.Range(0, SpwanPoints.Length);
        if (numSpawns < SpwanPoints.Length)
        {
            while (laneCounter[randomIndex] == 0)
            {
                randomIndex = Random.Range(0, SpwanPoints.Length);
            }
            laneCounter[randomIndex] = 0;
        }


        Transform spawnPoint = SpwanPoints[randomIndex];
        Instantiate(bird, spawnPoint.position, spawnPoint.rotation);

        numSpawns++;
    }
    void SpawnEgg()
    {
        //{
        //    int randomIndex = Random.Range(0, SpwanPoints.Length);
        //    if (numSpawns < SpwanPoints.Length)
        //    {
        //        while (laneCounter[randomIndex] == 0)
        //        {
        //            randomIndex = Random.Range(0, SpwanPoints.Length);
        //        }
        //        laneCounter[randomIndex] = 0;
        //    }
        GameObject[] birds = GameObject.FindGameObjectsWithTag("bird");
        int randomIndex = Random.Range(0, birds.Length);
        Transform EggspawnPoint = birds[randomIndex].transform;
       Instantiate(egg, EggspawnPoint.position, EggspawnPoint.rotation);
    }

}
