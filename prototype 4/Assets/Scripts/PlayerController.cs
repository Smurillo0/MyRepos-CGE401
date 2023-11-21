using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerUp = false;
    private float powerUpStrength = 15.0f;

    public GameObject powerupIndicator;

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

        //move our powerup indicator to the feet of player

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(Vector3.forward * speed * forwardInput);
        // first parameter, Vector3.forward - global direction
        //  playerRb.AddForce(Vector3.forward * speed * forwardInput);

        //move forward and back reletive to the camera
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());

          

            //when player collides with powerIndicator, it is trigegred - true
            powerupIndicator.SetActive(true);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            // get a local reference to enemy rn
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();

            //set a Vector3 with a direction away from thr player 
            //Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;


            //add force away from player 
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

        }
    }
}
