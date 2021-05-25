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
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    public GameObject UI;
    public Text UpgradeCost;
    public Text SellAmount;
    public Button UpgradeButton;
    private Tile targetTile;

    public void SetTargetTile(Tile tile)
    {
        targetTile = tile;

        transform.position = targetTile.GetBuildPosition() - new Vector2(0, 0.5f);

        if (!targetTile.IsUpgraded)
        {
            UpgradeCost.text = "$" + targetTile.TowerBlueprint.UpgradeCost;
            UpgradeButton.interactable = true;
        }
        else
        {
            UpgradeCost.text = "DONE";
            UpgradeButton.interactable = false;
        }

        SellAmount.text = "$" + targetTile.TowerBlueprint.GetSellAmount();
                
        Show();
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Show()
    {
        UI.SetActive(true);
    }

    public void Upgrade()
    {
        targetTile.UpgradeTower();
        BuildManager.Instance.DeselectTile();
    }

    public void Sell()
    {
        targetTile.SellTower();
        BuildManager.Instance.DeselectTile();
    }
}
