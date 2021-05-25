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

public class BuildManager : MonoBehaviour
{
    // Store instance of itself so there are not multiple build managers running around the scene
    public static BuildManager Instance;

    public bool CanBuild { get { return towerToBuild != null; } }

    public bool HasMoney { get { return Game.Money >= towerToBuild.Cost; } }

    public TileUI TileUI;

    private TowerBlueprint towerToBuild;
    private Tile selectedTile;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManger in the scene");
            return;
        }

        Instance = this;
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectTile();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SelectTile(Tile tile)
    {
        if (selectedTile == tile)
        {
            DeselectTile();
            return;
        }

        selectedTile = tile;
        towerToBuild = null;

        TileUI.SetTargetTile(tile);
    }

    public void DeselectTile()
    {
        selectedTile = null;
        TileUI.Hide();
    }
}
