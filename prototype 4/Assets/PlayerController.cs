using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(Vector3.forward * speed * forwardInput);
        // first parameter, Vector3.forward - global direction
        //  playerRb.AddForce(Vector3.forward * speed * forwardInput);

        //move forward and back reletive to the camera
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);


    }
}
