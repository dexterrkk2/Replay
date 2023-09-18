using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
namespace Cubethon.Command
{
    public class GameManager : MonoBehaviour
    {
        public bool gameHasEnded = false;
        public bool offStartMenu;
        public float restarDelay;
        public GameObject completeLevelUi;
        public PlayerMovement _playerMvmnt;
        private Invoker _invoker;
        public List<GameObject> ObstaclesToSpawn;
        public List<ObstacleMovement> obstacles;
        public float spawnTime;
        public float startSpawnTime;
        public float obstacleSpawnNum;
        public float incrementAdjuster;
        public int difficulty;
        public Transform spawnPoint;
        public int obstacleCounter;
        public TextMeshProUGUI ReplayText;
        public List<int> randomNums;
        private void Start()
        {
            obstacleCounter = 0;
            Data.instance.ResetTimer();
            _playerMvmnt = FindObjectOfType<PlayerMovement>();
            _invoker = FindObjectOfType<Invoker>();
            startSpawnTime = spawnTime;
            difficulty = Data.instance.difficulty;
            //startSpawn();
        }
        public void CompleteLevel()
        {
            completeLevelUi.SetActive(true);
            Debug.Log("Level won");
        }
        public void EndGame()
        {
            if (gameHasEnded == false)
            {
                gameHasEnded = true;
                for(int i =0; i<obstacles.Count; i++)
                {
                    obstacles[i].ResetPosition(spawnPoint);
                }
                _playerMvmnt.ResetPosition();
                spawnTime = startSpawnTime;
                obstacleCounter = 0;
                _invoker.Replay();
                Data.instance.ResetTimer();
                ReplayText.gameObject.SetActive(true);
            }
            else
            {
                CompleteLevel();
            }
        }
        private void FixedUpdate()
        {
            if (spawnTime < 0)
            {
                spawnTime = startSpawnTime - (Data.instance.timer / (incrementAdjuster / difficulty));
                if (spawnTime < .15)
                {
                    spawnTime = .15f;
                }
                if (!_invoker._isReplaying)
                {
                    spawnObstacles();
                }
                else if (obstacles.Count > 0)
                {
                    ReplaySpawns();
                }

            }
            spawnTime -= Time.fixedDeltaTime;
        }
        public void spawnObstacles()
        {

            int random = Random.Range(0, ObstaclesToSpawn.Count);
            GameObject obstacle = Instantiate(ObstaclesToSpawn[random], spawnPoint);
            ObstacleMovement obstaclemvmt = obstacle.GetComponent<ObstacleMovement>();
            randomNums.Add(random);
            obstacles.Add(obstaclemvmt);
            spawnPoint.DetachChildren();
        }
        public void ReplaySpawns()
        {
            int random = Random.Range(0, ObstaclesToSpawn.Count);
            GameObject obstacle = Instantiate(ObstaclesToSpawn[randomNums[obstacleCounter]], spawnPoint);
            ObstacleMovement obstaclemvmt = obstacle.GetComponent<ObstacleMovement>();
            spawnPoint.DetachChildren();
            obstacleCounter++;
        }
        public void startSpawn()
        {
            for (int i=0; i<obstacleSpawnNum; i++)
            {
                int random = Random.Range(0, ObstaclesToSpawn.Count);
                GameObject obstacle = Instantiate(ObstaclesToSpawn[random], spawnPoint);
                obstacle.SetActive(false);
                ObstacleMovement obstaclemvmt = obstacle.GetComponent<ObstacleMovement>();
                obstacles.Add(obstaclemvmt);
                spawnPoint.DetachChildren();
            }
        }
    }
}