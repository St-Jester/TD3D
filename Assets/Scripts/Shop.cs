using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standart;
    public TurretBlueprint missileLauncher;

    BuildManager bm;

	public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret purchase");
        bm.SelectTurret(standart);

    }
    public void SelectMissileLauncher()
    {
        Debug.Log("MissileLauncher purchase");
        bm.SelectTurret(missileLauncher);

    }


    private void Start()
    {
        bm = BuildManager.BM_instance;
    }
}
