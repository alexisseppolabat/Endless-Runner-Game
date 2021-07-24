using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public Rigidbody playerBody;
    public GameObject obstacle;
    public Transform playerSpawn;

    private List<GameObject> obstacles;
    private readonly System.Random random = new System.Random();
    private GameObject[] obstacleSpawnPoints;


    private void Start() {
        obstacles = new List<GameObject>();
        obstacleSpawnPoints = GameObject.FindGameObjectsWithTag("Obstacle Spawn");

        // Randomly spawn obstacles in the obstacle spawn points
        foreach (GameObject spawnPoint in obstacleSpawnPoints) {
            if (random.Next(0, 2) == 1) 
                obstacles.Add(
                    Instantiate(obstacle, spawnPoint.transform.position, new Quaternion())
                );
        }
    }

    public void UpdateWorld() {
        foreach (GameObject obstacleBlock in obstacles) {
            Destroy(obstacleBlock);
        }

        Start();
        Vector3 position = playerSpawn.position;
        playerBody.MovePosition(
            new Vector3(playerBody.position.x, position.y, position.z)
        );
    }
}
