using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{    
    [SerializeField] private GameObject player;
    [SerializeField] private float distanseToSpawnObstacle;
    [SerializeField] private Transform destinationPoint;

    private bool canSpawn = false;
    private Obstacle newObstacle;
    private void Start()
    {
        newObstacle = ObstaclesPool.pool.Dequeue();
        newObstacle.destinationPoint = destinationPoint;
    }
    

    private void Update()
    {
        if (!canSpawn) SpawningCondition();
        else
        {
            newObstacle.transform.position = transform.position;
            newObstacle.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    private void SpawningCondition()
    {
        Debug.Log((transform.position - player.transform.position).magnitude);
        if ((transform.position - player.transform.position).magnitude < distanseToSpawnObstacle)
            canSpawn= true;
    }
}
