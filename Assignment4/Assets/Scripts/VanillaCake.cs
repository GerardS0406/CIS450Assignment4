/*
 * Gerard Lamoureux
 * UpdateBakeTimer
 * Assignment 4
 * Handles Vanilla Cake Component
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanillaCake : Cake
{
    public VanillaCake()
    {
        this.description = "Vanilla Extract, Flour, Sugar, Eggs, Milk";
    }
    public override float GetCost()
    {
        return 10;
    }
}
