using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private GameState currentState;
    public event Action<GameState> GameStateChanged;
    public GameState CurrentState=>currentState;
    
    void Start()
    {
        if(PlayerPrefs.GetInt("FirstGame")==0)
        {
            UpdateGameState(GameState.Start);
            Time.timeScale=0;
        }
        else
        {
            UpdateGameState(GameState.OnJump);
            Time.timeScale=1;
        }
        
    }

    public void UpdateGameState(GameState newState)
    {
        GameStateChanged?.Invoke(newState);
        currentState=newState;
        if(currentState==GameState.Fail || currentState==GameState.Succes)
        {
            PlayerPrefs.SetInt("FirstGame",1);
            LeanTween.delayedCall(1f,()=>{ SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);});
           
        }
    }
}
