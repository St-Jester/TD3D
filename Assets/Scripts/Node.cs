using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color noMoney;

    public Vector3 positionOffset;

    [HideInInspector]
    private GameObject turret;

    [HideInInspector]
    public TurretBlueprint Tblueprint;

    private Color startColor;
    private Renderer rend;
    BuildManager bm;


    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        bm = BuildManager.BM_instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            bm.SelectNode(this);
            //Debug.Log("Already Claimed!");
            return;
        }

        if (!bm.CanBuild)
        {
            return;
        }


        BuildTurret(bm.GetTurretToBuild());
        //build turret in a this script
        
        
    }

    public void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.price)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= blueprint.price;

         
        GameObject _turret = Instantiate(blueprint.turret, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        Tblueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(bm.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Built");
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("overlap");

            return;
        }
        if (!bm.CanBuild)
        {
            Debug.Log("cantbuild");

            return;
        }

        if(bm.HasMoney)
        {
            Debug.Log("Has money");
            rend.material.color = hoverColor;

        }
        else
        {
            Debug.Log("no money");

            rend.material.color = noMoney;
        }

    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }


}
