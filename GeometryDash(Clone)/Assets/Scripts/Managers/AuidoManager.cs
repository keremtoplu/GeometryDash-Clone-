using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource gameMusic;
    void Start()
    {
        GameManager.Instance.GameStateChanged+=OnGameStateChanged;
        if(PlayerPrefs.GetInt("FirstGame")==0)
            PlayerPrefs.SetInt("SoundActive",1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            
            case GameState.Start:
               
                gameMusic.Play();

                break;
            case GameState.OnJump:

                if(PlayerPrefs.GetInt("SoundActive")==1)
                {
                    gameMusic.Play();
                }
                else
                {
                    gameMusic.Stop();
                }
                break;
        }
    }
}
