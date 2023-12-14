using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 5.0f;
    [SerializeField] private float speed;
    [SerializeField] private float RPM;
    private float horizontalInput;
    private float verticalInput;
    public float horsepower;

    public Rigidbody playerRb;
    
    [SerializeField] GameObject CenterOfmass;
    [SerializeField] TextMeshProUGUI Speedometretext;
    [SerializeField] TextMeshProUGUI RPMtext;
 
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
        RPM = Mathf.Round((speed % 30) * 40);

        Speedometretext.SetText("Speed: " + speed + "mph");
        RPMtext.SetText("RPM : " + RPM);
    }
}
