using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    public Transform destinationPoint;
    private float speed;
    private void Start()
    {        
        transform.LookAt(destinationPoint.position);
        speed = Random.Range(minSpeed, maxSpeed);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint.position, speed * Time.deltaTime);
        if(transform.position == destinationPoint.position)
        {
            this.gameObject.SetActive(false);
            ObstaclesPool.pool.Enqueue(this);
        }
    }
}
