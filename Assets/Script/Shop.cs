using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint MissileLauncherTurret;
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

    }
    public void SelectStrandardTurret()
    {

        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {

        buildManager.SelectTurretToBuild(MissileLauncherTurret);
    }
}
