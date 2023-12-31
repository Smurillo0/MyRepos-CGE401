using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManage : Singleton<GameManage>
{  public int score;

    public GameObject pauseMenu;

    //variable to keep track of what level we are on
    private string CurrentLevelName = string.Empty;
    //singleton 
 /*   public static GameManage instance;

    private void Awake()
    {
        // if not set up..then
       if(instance == null)
        {
            instance = this;
            // make sure this game manager persists across scenes
            DontDestroyOnLoad(gameObject);
        }
       else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" + "instance of singleton GameManager");
        }
    }*/

    //method to load and unload scenes

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        if (ao == null)
        {
            Debug.LogError("[GameManage] Unable to load level " + levelName);  
            return;
        }
        CurrentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);

        if (ao == null)
        {
            Debug.LogError("[GameManage] Unable to unload level " + levelName);
            return;
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);

        if (ao == null)
        {
            Debug.LogError("[GameManage] Unable to unload level " + CurrentLevelName);
            return;
        }
    }

    // pausing and unpausing 

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    
}
   
