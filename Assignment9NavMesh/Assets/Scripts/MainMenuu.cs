using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuu : MonoBehaviour
{
    public void FirstScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }

    public void SecondScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ThirdScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void FourthScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void FifthScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void SixthScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }




}
