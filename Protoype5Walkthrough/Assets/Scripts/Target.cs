﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;



    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //add a force upwards multupied by a randomized speed 
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add a torque (rotational force)0 with a randomized 
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //set the position w a randomized X value

        transform.position = RandomSpawnPos();

        //set reference to game manager object
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    
   private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
           gameManager.UpdateScore(pointValue);

           Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
           Destroy(gameObject);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // if click/ trigger a bad object then game over 
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

        Destroy(gameObject);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
