using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private Obstacle[] obstaclePrefabs;
    [SerializeField] private int queueCapacity;
    
    public static Queue<Obstacle> pool = new Queue<Obstacle>();

    private void Awake() => CreatePool();
    private void CreatePool()
    {
        for (int i = 0; i < queueCapacity; i++) 
        {
            Obstacle newObstacle = GameObject.Instantiate(obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)]); 
            newObstacle.gameObject.SetActive(false);
            pool.Enqueue(newObstacle);            
        }
    }
  
    
}
