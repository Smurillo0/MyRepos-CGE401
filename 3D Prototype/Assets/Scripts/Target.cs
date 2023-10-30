using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;

    private DisplayScore displayScoreS;
     private void Start()
    {
        displayScoreS = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
           // displayScoreS.score++;
            Die();
            
        }
        displayScoreS.score++;

    }
    


    void Die()
    {
        //displayScoreS.score++;
        Destroy(gameObject);
    }

   

    // Update is called once per frame
    void Update()
    {
       
    }
}
