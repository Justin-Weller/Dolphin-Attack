using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject dolphin;
    public float spawnDelay = 2;    
    public int dolphinsToSpawn = 2;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI countdownText;
    public int waveNumber = 0;

    public GameObject chest;

    private Transform[] spawnPoints;
    public List<GameObject> dolphinsInScene;
    
    private float dolphinGravityScale = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Gets all the spawnpoints and stores their transform components in the array
        spawnPoints = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        StartCoroutine(startWave(dolphinsToSpawn));
    }

    // Update is called once per frame
    void Update()
    {
        int numOfDeadDolphins = 0;
        foreach (GameObject d in dolphinsInScene)
        {
            if (d == null) {
                numOfDeadDolphins++;
            }
        }

        if(numOfDeadDolphins == dolphinsToSpawn) {
            increaseDifficulty();
            StartCoroutine(startWave(dolphinsToSpawn));
        }
    }

    void increaseDifficulty() {
        //Adds 0.5 every round
        dolphinGravityScale += waveNumber / 2;
        //Number of dolphins increases every 3 rounds
        dolphinsToSpawn += (int) (waveNumber / 3);
    }

    private IEnumerator startWave(int numDolphins)
    {
        waveNumber += 1;
        dolphinsInScene = new List<GameObject>();
        
        if(waveNumber == 1) {
            countdownText.gameObject.SetActive(true);
            countdownText.text = "3";
            yield return new WaitForSeconds(1);
            countdownText.text = "2";
            yield return new WaitForSeconds(1);
            countdownText.text = "1";
            yield return new WaitForSeconds(1);
            countdownText.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(1);
        roundText.gameObject.SetActive(true);
        roundText.text = "ROUND " + waveNumber.ToString();

        if (waveNumber != 1) {
            chest.GetComponent<ChestController>().showChest();
            chest.GetComponent<ChestController>().closeChest();
        }
        
        yield return new WaitForSeconds(2);
        
        while(numDolphins != 0)
        {
            // Choose a random spawn location. Exclude the parent at index 0
            int randSpawnIndex = Random.Range(1, spawnPoints.Length);

            GameObject spawnedDol = Instantiate(dolphin, new Vector2(spawnPoints[randSpawnIndex].position.x, spawnPoints[randSpawnIndex].position.y), Quaternion.identity);
            spawnedDol.GetComponent<Rigidbody2D>().gravityScale = dolphinGravityScale;
            dolphinsInScene.Add(spawnedDol);

            numDolphins--;

            // Delay before spawning a new dolphin
            yield return new WaitForSeconds(spawnDelay);
        }

    }
}
