using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {


    BuildManager bm;
	public void PurchasesStandartTurret()
    {
        Debug.Log("Standart Turret purchase");
        bm.SetTurretToBuild(bm.standartTurret);

    }
    public void PurchasesMissileLauncher()
    {
        Debug.Log("MissileLauncher purchase");
        bm.SetTurretToBuild(bm.missileLauncher);

    }


    private void Start()
    {
        bm = BuildManager.BM_instance;
    }
}
