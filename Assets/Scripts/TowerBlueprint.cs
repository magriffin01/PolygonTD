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

// Used to make these fields editable in the editor
[System.Serializable]
// Will be used to clean up the Tower purchasing, selection
public class TowerBlueprint
{
    public GameObject Prefab;
    public int Cost;

    public GameObject UpgradedPrefab;
    public int UpgradeCost;

    public int GetSellAmount()
    {
        return Cost / 2;
    }
}
