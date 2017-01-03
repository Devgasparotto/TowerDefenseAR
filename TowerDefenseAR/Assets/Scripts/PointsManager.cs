using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {
    public static PointsManager instance;
    
    private int points = 0;
    private int pointsPerKill = 100;
    private int pointsPerHit = 10;
    private int pointsCostPerCastleHit = 50;
    private int turretCost = 2250;
    private string pointsTextConstant = "Points: ";

    private int startingPoints = 2250;

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
        points = startingPoints;
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

    //Returns true if turret was purchased, returns false if turret can't be purchased
    public bool PurchaseTurret()
    {
        if (points >= turretCost)
        {
            points -= turretCost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void LostHealth()
    {
        if (points > 0)
        {
            points -= pointsCostPerCastleHit;
        }
    }

    public void ResetPoints()
    {
        points = startingPoints;
    }

}
