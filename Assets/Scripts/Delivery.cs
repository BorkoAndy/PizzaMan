using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Transform pizzaSpawnPoint;
    [SerializeField] private GameObject pizza;
    [SerializeField] private float pizzaFlyingSpeed;

    private Transform _destinationPoint;
  
    private void Start()
    {
        pizza.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        ThrowPizza(other.gameObject.transform);
    }
    private void ThrowPizza(Transform target)
    {        
        _destinationPoint = target.transform.parent;
        pizza.transform.position = pizzaSpawnPoint.position;
        pizza.SetActive(true);        
    }
    private void Update()
    {
        if (pizza.activeInHierarchy)
        {
            pizza.transform.position = Vector3.MoveTowards(pizza.transform.position, _destinationPoint.position, pizzaFlyingSpeed * Time.deltaTime);
        }
    }


}
