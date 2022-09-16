using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
   private float x;
   private float y;

    public Coordinate(float x, float y)
    {
        this.x=x;
        this.y=y;
    }

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }

    
}
