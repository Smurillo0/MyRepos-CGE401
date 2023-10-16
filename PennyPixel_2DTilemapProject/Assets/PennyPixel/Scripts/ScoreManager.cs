/*
 * Sarahi Murillo
 * Project 5A
 * This script is added to an object in the scene to manage the score and display a text on the canvas. I was having a hard time figuring out debuggind an error in the void start(). When I run it, It gives me a null error. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    

    public PlayerPlatformerController playerControllerScript;

   string S = "Score : 0 / 10";

    public bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        if(scoreText == null)
        {
            scoreText = FindAnyObjectByType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        }

       // scoreText.text = S;
        // scoreText.text = "Score: 0 / 10";
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        if(playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }


        //win
        if(score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            scoreText.text = "You Win!\nPress R to Try Again!";

        }

        if(playerControllerScript.gameOver && Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    private void OnTriggerEnter(Collider gem)
    {
        if(gem.tag == "Gems")
        {
            score++;
        }
    }
}
