/*
 * Gerard Lamoureux
 * UpdateBakeTimer
 * Assignment 4
 * Handles Icing Designs Decorator
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcingDesigns : CakeDecorator
{
    Cake cake;

    public IcingDesigns(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Icing Designs";
    }
    public override float GetCost()
    {
        return cake.GetCost() + 8;
    }
}
