﻿/*
Sarahi Murillo
Challenge 4

GameObject reference not initialized in Start()
 
 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;

    //game object not initialized 
    private GameObject playerGoal;
    private SpawnManagerX spawnManagerScript;
    private LevelManager levelManager;
     

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        playerGoal = GameObject.Find("Player Goal");

        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        speed = spawnManagerScript.enemySpeed;

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);

            
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);

            levelManager.gameOver = true;
            // GameOver
        }

    }

}
