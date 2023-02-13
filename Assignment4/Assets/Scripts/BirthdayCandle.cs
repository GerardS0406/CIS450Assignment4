/*
 * Gerard Lamoureux
 * UpdateBakeTimer
 * Assignment 4
 * Handles Birthday Candle Decorator
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthdayCandle : CakeDecorator
{
    Cake cake;

    public BirthdayCandle(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Birthday Candle";
    }
    public override float GetCost()
    {
        return cake.GetCost() + .50f;
    }
}
