/*
 * Sarahi Murillo
 * 3D prototype walkthrough 
 * I attempted to have a kill count but ran into problems especially with the player control script. 
 * i tried to add score method when the enemy is destroyed but ran into problems
 
 
 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class Target : MonoBehaviour
{

    public float health = 50f;

    public bool isEnemy = true;

    private ScoreScript score;

     void Awake()
    {
        GameObject scoreObject = GameObject.Find("ScoreText");
        score = scoreObject.GetComponent<ScoreScript>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
            Die();
            // Attempted to call on UpdateScore() to add points when enemy is detroyed
            score.UpdateScore();
        }
    }  
    void Die()
    {
       // score.UpdateScore();
        Destroy(gameObject);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
