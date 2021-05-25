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

public class Tile : MonoBehaviour
{
    public Color HoverColor;
    public Color InsufficientFundsColor;
    private Color startColor;

    [HideInInspector]
    public GameObject Tower;
    [HideInInspector]
    public TowerBlueprint TowerBlueprint;
    [HideInInspector]
    public bool IsUpgraded = false;

    private BuildManager buildManager;

    private void Start()
    {
        startColor = GetComponent<SpriteRenderer>().color;
        buildManager = BuildManager.Instance;
    }

    public Vector2 GetBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            GetComponent<SpriteRenderer>().color = HoverColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = InsufficientFundsColor;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = startColor;
    }

    private void OnMouseDown()
    {
        if (Tower != null)
        {
            buildManager.SelectTile(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTower(buildManager.GetTowerToBuild());
    }

    public void UpgradeTower()
    {
        if (Game.Money < TowerBlueprint.UpgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        Game.Money -= TowerBlueprint.UpgradeCost;

        Destroy(Tower);
        GameObject tower = (GameObject)Instantiate(TowerBlueprint.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
        Tower = tower;

        IsUpgraded = true;

        Debug.Log("Tower upgraded!");
    }

    public void SellTower()
    {
        Game.Money += TowerBlueprint.GetSellAmount();
        Destroy(Tower);
        TowerBlueprint = null;
    }

    private void BuildTower(TowerBlueprint blueprint)
    {
        if (Game.Money < blueprint.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        Game.Money -= blueprint.Cost;

        GameObject tower = (GameObject)Instantiate(blueprint.Prefab, GetBuildPosition(), Quaternion.identity);
        Tower = tower;

        TowerBlueprint = blueprint;

        Debug.Log("Tower built!");
    }
}
