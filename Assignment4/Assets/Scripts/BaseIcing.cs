using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIcing : CakeDecorator
{
    Cake cake;

    public BaseIcing(Cake cake)
    {
        this.cake = cake;
    }
    public override string GetIngredients()
    {
        return cake.GetIngredients() + ", Base Icing Layer";
    }
    public override float GetCost()
    {
        return cake.GetCost() + 10;
    }
}
