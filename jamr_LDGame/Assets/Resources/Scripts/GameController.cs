using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    float extraPoints = 0;
    float score = 0;
    float waveInterval = 10;
    float timeSinceLastWave = 0;
    int obstaclesToSpawn = 2;
    float obstacleSpeed = 0f;

    public bool isAlive;

    //UI Outlets
    public Text scoreText;
    public Canvas endGameScreen;

    //obstacle Outlets
    public GameObject[] spawnPoints;
    public GameObject[] asteroids;

    public static GameController instance;

 

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        extraPoints = 0;
        isAlive = true;
        UpdateInterface();
        timeSinceLastWave = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            
            extraPoints += Time.deltaTime / 10;
            score += Time.deltaTime * 10 + extraPoints;
            obstacleSpeed = CalculateSpeed();
            if (CheckSpawnWave())
            {
                SpawnAsteroid();
                
                timeSinceLastWave = Time.time;
            }
        }
        
        UpdateInterface();

        if (!isAlive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    

    void UpdateInterface()
    {
        scoreText.text = Mathf.Floor(score).ToString();
    }

    public float CalculateSpeed()
    {
        return 5 + Mathf.Log(1 + (score / 400), 1.05f);
    }

    public float GetSpeed()
    {
        if (isAlive)
        {
            return obstacleSpeed;
        }

        return 0;
    }

    bool CheckSpawnWave()
    {
        //waveInterval = 1.15f + 10 / (score / 500);
        waveInterval = 1.15f;
        if (Time.time > timeSinceLastWave + waveInterval)
        {
            Debug.Log("waveInterval: " + waveInterval);
            return true;
        }
        return false;
    }

    void SpawnAsteroid()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int asteroidToSpawn = Random.Range(0, asteroids.Length);
            Vector3 startingPosition = spawnPoints[i].transform.position + RandomSpawnPoint();
            Instantiate(asteroids[asteroidToSpawn], startingPosition, new Quaternion());
        }

    }

    public void EndGame()
    {
        isAlive = false;
        endGameScreen.gameObject.SetActive(true);
        scoreText.color = Color.white;
    }

    Vector3 RandomSpawnPoint()
    {
        float xBound = 7;
        float yBound = 7;

        return new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound));
    }
}
