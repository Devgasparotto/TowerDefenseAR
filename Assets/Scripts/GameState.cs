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
        inPlay
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
        currentState = state.paused;
    }

    private void RestartGame()
    {
        //TODO
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
        else
        {
            PauseGame();
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
}
