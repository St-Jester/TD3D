using UnityEngine;

public class BuildManager : MonoBehaviour {

    [HideInInspector]
    public static BuildManager BM_instance;

    
    public GameObject standartTurret;
    public GameObject missileLauncher;
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= BM_instance.turretToBuild.price; } }
    
    private Node selectedNode;

    private void Awake()
    {
        if(BM_instance != null)
        {
            Debug.Log("More then one BM!");
            return;
        }
        BM_instance = this;
    }




    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {

        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        //nodeUI.SetTarget(node);
    }
   
    public void SelectTurret(TurretBlueprint t)
    {
        turretToBuild = t;
        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        //nodeUI.Hide();
    }

    

}
