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

public class Waypoints : MonoBehaviour
{
    public static Transform[] Points;

    // Creates an array of Waypoints
    private void Awake()
    {
        Points = new Transform[transform.childCount];

        for (int childIndex = 0; childIndex < Points.Length; childIndex++)
        {
            Points[childIndex] = transform.GetChild(childIndex);
        }
    }
}
