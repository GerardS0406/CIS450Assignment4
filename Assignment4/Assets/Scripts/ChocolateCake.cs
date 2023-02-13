using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateCake : Cake
{
    public ChocolateCake()
    {
        this.description = "Cocoa Powder, Flour, Sugar, Eggs, Milk";
    }
    public override float GetCost()
    {
        return 12;
    }
}
