
/*
 * Sarahi Murillo
 * 3D prototype walkthrough 
 * I attempted to have a kill count but ran into problems especially with the player control script. 
 
 
 
 */

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public FirstPersonController playerController;

    public bool won = false;

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        }

      //  scoreText.text = "Score: 0";


    }

    public void UpdateScore()
    {
        score++;
    }
    void Update()
    {
        if(!playerController.gameO)
        {
            UpdateScore();
            scoreText.text = "Make it to the end! ";

        }

        if(score >= 10)
        {
            playerController.gameO = true;
            won = true;

            //scoreText.text = "You Win!" + "\n" + "Press R to Try Again";
        }

        if(playerController.gameO && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
