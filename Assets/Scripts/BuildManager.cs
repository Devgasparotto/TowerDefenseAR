using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;
    private node targetNode;

    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
        }
        instance = this;
    }

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    private void UnhighlightCurrentNode()
    {
        if (targetNode != null)
        {
            targetNode.Unhighlight();
        }
    }

    private void HighlightCurrentNode()
    {
        if (targetNode != null)
        {
            targetNode.Highlight();
        }
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(node selectedNode){
        UnhighlightCurrentNode();
        targetNode = selectedNode;
        HighlightCurrentNode();
        Debug.Log("node selected");
    }

    public void UnselectNode()
    {
        targetNode = null;
    }

    public void TurretButtonPressed()
    {
        //Attempt to Build turret
        if (targetNode != null)
        {
            targetNode.BuildTurret();
        }
    }
}
