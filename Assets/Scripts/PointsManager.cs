using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {
    public static PointsManager instance;
    
    private int points = 0;
    private int pointsPerKill = 100;
    private int pointsPerHit = 10;
    private string pointsTextConstant = "Points: ";

    public Text pointsCounterText;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one PointsManager in scene");
        }
        instance = this;
    }

    void Start()
    {
        points = 500;
        UpdatePointsCounter();
    }

    private void UpdatePointsCounter()
    {
        pointsCounterText.text = pointsTextConstant + points.ToString();
    }

    public void AllocatePointsForHit()
    {
        points += pointsPerHit;
        Debug.Log("Hit");
        UpdatePointsCounter();
    }

    public void AllocatePointsForKill()
    {
        points += pointsPerKill;
        Debug.Log("Kill");
        UpdatePointsCounter();
    }


}
