using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamCake : Cake
{
    public IceCreamCake()
    {
        this.description = "Chocolate Ice Cream, Vanilla Ice Cream, Hot Fudge, Crushed Cookies";
    }

    public override float GetCost()
    {
        return 20;
    }
}
