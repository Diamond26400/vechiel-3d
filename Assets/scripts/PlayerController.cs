using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 5.0f;
    private float horizontalInput;
    [SerializeField] private float speed = 10.0f;
    private float verticalInput;
    public Rigidbody playerRb;
    public float horsepower;
    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //  move vehicle forward  
        playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsepower);
       // transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
       // transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }
}
