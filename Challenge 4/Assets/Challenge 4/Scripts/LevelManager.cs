using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public bool won;
    public bool gameOver;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            if(won == true)
            {
                scoreText.text = "You Won!" + "\n" + "Press R to Try Again!";
            }
            else 
            {
                scoreText.text = "You Lost!" + "\n" + "Press R to Try Again!";
            }
        }

        if (gameOver && Input.GetKeyUp(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
