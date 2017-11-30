using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour {

    public Color hoverColor;

    private GameObject turret;

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
        if (bm.GetTurretToBuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Already Claimed!");
            return;
        }
        GameObject turretToBuild = BuildManager.BM_instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position+ BuildManager.BM_instance.PositionOffset, transform.rotation);
        
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (bm.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;

    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }


}
