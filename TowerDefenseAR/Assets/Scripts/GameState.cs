using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    public static GameState instance;
    public int health = 0;
    public Text healthCounterText;

    private string healthTextConstant = "Health: ";
    private enum state
    {
        paused,
        inPlay,
        gameOver
    }
    private state currentState;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameState in scene");
        }
        instance = this;
    }

    void Start()
    {
        health = 20;
        UpdateHealthText();
        currentState = state.paused;

        //Explain Rules
        #if UNITY_EDITOR
        UnityEditor.EditorUtility.DisplayDialog("Rules", @"This is a tower defense AR game: 
            - To display the map, focus phone camera on Leaves image.
            - If image is lost map may still display and function. Focus on Leaves image to redisplay map.
            - The goal is to destroy spawning enemies with turrets and accumulate points.
            - If 20 enemies reach the Castle, the game ends.
            - Place turrets by pressing on a white square and pressing the turrets button.
            - Turrets may only be placed while In Play and cost 2250 points.
            - Pressing the Start button will put the game In Play.
            - Pressing the Start button while In Play, will Pause the game.
            ", "Good Luck!");
        #endif
    }

    private void PauseGame()
    {
        Debug.Log("Game Paused");
        currentState = state.paused;
    }

    private void StartGame()
    {
        Debug.Log("Game Resumed");
        currentState = state.inPlay;
    }

    private void EndGame()
    {
        Debug.Log("Game is over");
        currentState = state.gameOver;
        #if UNITY_EDITOR
        UnityEditor.EditorUtility.DisplayDialog("Game Over", "", "Return to Game");
        #endif
    }

    private void RestartGame()
    {
        Start();
        PointsManager.instance.ResetPoints();
        WaveSpawner.instance.ResetWaves();
        StartGame();
    }

    private void UpdateHealthText()
    {
        healthCounterText.text = healthTextConstant + health.ToString();
    }

    public void StartButtonPress(){
        Debug.Log("Start button pressed");
        if (currentState == state.paused)
        {
            StartGame();
        }
        else if(currentState == state.inPlay)
        {
            PauseGame();
        }
        else if (currentState == state.gameOver)
        {
            RestartGame();
        }
    }

    public void EndReached()
    {
        health--;
        UpdateHealthText();
        if (health <= 0)
        {
            EndGame();
        }
    }

    public string GetGameState()
    {
        return currentState.ToString();
    }

    public bool IsInPlay()
    {
        return currentState == state.inPlay;
    }

    public bool IsGameOver()
    {
        return currentState == state.gameOver;
    }
}
