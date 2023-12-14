using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 5.0f;
    private float horizontalInput;
    [SerializeField] private float speed;
    private float verticalInput;
    public Rigidbody playerRb;
    public float horsepower;
    [SerializeField] GameObject CenterOfmass;
    [SerializeField] TextMeshProUGUI Speedometre;
    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = CenterOfmass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //  move vehicle forward  
        playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsepower);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
       transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        speed += Mathf.Round(playerRb.velocity.magnitude*2.237f); //3.6 for KpH

        Speedometre.SetText("Speed: " + speed + "mph");
    }
}
