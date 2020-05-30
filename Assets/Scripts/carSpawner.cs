using Random = UnityEngine.Random;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject car;
    public int max = 4;
    //public Transform[] SpwanPoints;
    public float countDownSpawnTimer = 3f;
    int[] laneCounter;
    int numSpawns = 0;
    // Start is called before the first frame update
    void Start()
    {
        //laneCounter = new int[SpwanPoints.Length];
        //for (int i = 0; i < SpwanPoints.Length; i++)
        //{
        //    laneCounter[i] = 1;
        //}  
    }

    // Update is called once per frame
    void Update()
    {
        if (numSpawns < max)
        {
            if (countDownSpawnTimer <= 0f)
            {
                SpawnCar();
                countDownSpawnTimer = 2f;
            }
            else
            {
                countDownSpawnTimer -= Time.deltaTime;
            }
        }
    }

    void SpawnCar()
    {
        //int randomIndex = Random.Range(0, SpwanPoints.Length);
        Transform spawnPoint = transform;
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
        numSpawns++;
    }

}
