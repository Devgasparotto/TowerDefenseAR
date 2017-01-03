using UnityEngine;

public class node : MonoBehaviour {

    private Renderer rend;
    private Color startColor;

    private GameObject turret;

    public Color hoverColor;
    public Vector3 positionOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        //BuildTurret();
    }

    void OnMouseEnter()
    {
        //rend.material.color = hoverColor;
        SelectNode();
    }

    void OnMouseExit()
    {
        //rend.material.color = startColor;
    }

    //TODO: This may be bad design because of cyclical reference!!!
    public void BuildTurret()
    {
        if (GameState.instance.IsInPlay())
        {
            if (turret != null) //already built something here
            {
                Debug.Log("Can't build there");
                return;
            }

            //Build a turret
            if (PointsManager.instance.PurchaseTurret())
            {
                GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            }
        }
    }

    public void SelectNode(){
        BuildManager.instance.SelectNode(this);
    }

    public void Unhighlight()
    {
        rend.material.color = startColor;
    }

    public void Highlight()
    {
        rend.material.color = hoverColor;
    }
}
