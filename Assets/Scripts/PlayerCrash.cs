using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    [SerializeField] private ParticleSystem partSystem;

   
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            partSystem.transform.position = transform.position;
            partSystem.Play();                
            gameObject.SetActive(false);
        }
    }

}
