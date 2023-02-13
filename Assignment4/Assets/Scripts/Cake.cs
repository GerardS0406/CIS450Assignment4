using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cake
{
    public string description = "Unknown Cake";
    public virtual string GetIngredients()
    {
        return description;
    }
    public abstract float GetCost();
}
