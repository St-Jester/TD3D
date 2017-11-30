using UnityEngine;

public class BuildManager : MonoBehaviour {

    [HideInInspector]
    public static BuildManager BM_instance;

    public Vector3 PositionOffset;
    public GameObject standartTurret;
    public GameObject missileLauncher;

    private GameObject turretToBuild;

    private void Awake()
    {
        if(BM_instance != null)
        {
            Debug.Log("More then one BM!");
            return;
        }
        BM_instance = this;
        
        
    }


    public void SetTurretToBuild(GameObject _tur)
    {
        turretToBuild = _tur;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
