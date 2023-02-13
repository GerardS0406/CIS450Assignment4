/*
 * Gerard Lamoureux
 * UpdateBakeTimer
 * Assignment 4
 * Handles Sprinkles/Cookies Toppings Decorators
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinkles : CakeDecorator
{
    Cake cake;

    public Sprinkles(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Sprinkles";
    }
    public override float GetCost()
    {
        return cake.GetCost() + 2f;
    }
}

public class CrushedCookies : CakeDecorator
{
    Cake cake;

    public CrushedCookies(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Crushed Cookies";
    }
    public override float GetCost()
    {
        return cake.GetCost() + 8f;
    }
}
