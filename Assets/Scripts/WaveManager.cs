using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject dolphin;
    public float spawnDelay = 2;
    private Transform[] spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gets all the spawnpoints and stores their transform components in the array
        spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();

        StartCoroutine(startWave(3));
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    private IEnumerator startWave(int numDolphins)
    {
        while(numDolphins != 0)
        {
            // Choose a random spawn location. Exclude the parent at index 0
            int randSpawnIndex = Random.Range(1, spawnPoints.Length);

            Instantiate(dolphin, new Vector2(spawnPoints[randSpawnIndex].position.x, spawnPoints[randSpawnIndex].position.y), Quaternion.identity);

            numDolphins--;

            // Delay before spawning a new dolphin
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
