/*
# Name: Mark Griffin
# Student ID#: 2340502
# Chapman email: magriffin@chapman.edu
# Course Number and Section: 236-02
# Assignment: Final Project
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint StandardTower;
    public TowerBlueprint ExplosiveTower;
    public TowerBlueprint SniperTower;
    public TowerBlueprint MachineGunTower;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectStandardTower()
    {
        Debug.Log("Standard Tower Selected");
        buildManager.SelectTowerToBuild(StandardTower);
    }

    public void SelectExplosiveTower()
    {
        Debug.Log("Explosive Tower Selected");
        buildManager.SelectTowerToBuild(ExplosiveTower);
    }

    public void SelectSniperTower()
    {
        Debug.Log("Sniper Tower Selected");
        buildManager.SelectTowerToBuild(SniperTower);
    }    

    public void SelectMachineGunTower()
    {
        Debug.Log("Machine Gun Tower Selected");
        buildManager.SelectTowerToBuild(MachineGunTower);
    }
}
