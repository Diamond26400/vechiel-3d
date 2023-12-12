using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed = 10f;
    public GameObject carPrefab;
    public bool needcar = true;
    public Transform spawnpoint;
   
    void Update()
    {
       

        transform.position += speed * Time.deltaTime * transform.forward;
    }

  

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(collision.gameObject);
        }
    }

}