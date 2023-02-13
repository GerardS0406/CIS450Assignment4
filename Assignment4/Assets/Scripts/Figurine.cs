using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticFigurine : CakeDecorator
{
    Cake cake;

    public PlasticFigurine(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Plastic Figurine";
    }
    public override float GetCost()
    {
        return cake.GetCost() + 10f;
    }
}

public class PorcelainFigurine : CakeDecorator
{
    Cake cake;

    public PorcelainFigurine(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Porcelain Figurine";
    }
    public override float GetCost()
    {
        return cake.GetCost() + 50f;
    }
}
