using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject soundButton;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOfSprite;

    private bool isClicked=false;

    void Awake()
    {
        GameManager.Instance.GameStateChanged+=OnGameStateChanged;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        GameManager.Instance.UpdateGameState(GameState.OnJump);
        Time.timeScale=1f;
    }
    public void ChangeSound()
    {
        if(!isClicked)
        {
            AudioListener.pause=true;
            soundButton.GetComponent<Image>().sprite=soundOfSprite;
            PlayerPrefs.SetInt("SoundActive",0);
            isClicked=true;


        }
        else
        {
            isClicked=false;
            AudioListener.pause=false;
            PlayerPrefs.SetInt("SoundActive",1);
            soundButton.GetComponent<Image>().sprite=soundOnSprite;
        }
    }

     private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            
            case GameState.Start:
                mainMenuPanel.SetActive(true);
                break;
            case GameState.OnJump:
                mainMenuPanel.SetActive(false);
                break;
            case GameState.OnGravity:
                break;
            case GameState.Succes:
                break;
        
            
        }
    }
}
