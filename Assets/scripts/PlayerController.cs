using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 5.0f;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    private float horizontalInput;
    private float verticalInput;
    public float horsepower;

    public Rigidbody playerRb;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    [SerializeField] GameObject CenterOfmass;
    [SerializeField] TextMeshProUGUI Speedometretext;
    [SerializeField] TextMeshProUGUI rpmtext;

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
        if (IsOnGround())
        {

            //  move vehicle forward  
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsepower);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            //calculating speed of vechiel
            speed += Mathf.Round(playerRb.velocity.magnitude * 2.237f); //3.6 for KpH
            Speedometretext.SetText("Speed:" + speed + "mph");

            //calculating RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmtext.SetText("RPM:" + rpm);

        }
        bool IsOnGround()
        {
            wheelsOnGround = 0;
            foreach (WheelCollider wheel in allWheels)
            {
                if (wheel.isGrounded)
                {
                    wheelsOnGround++;
                }
            }
            if (wheelsOnGround == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
