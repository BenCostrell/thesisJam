using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavQuad {

    public readonly Vector3 position;
    public List<NavQuad> neighbors;
    public float movementCost;
    public const int quadsPerTile = 100; //always has to be a square number

	public NavQuad(Vector3 position_)
    {
        position = position_;
    }

    public float Distance(NavQuad other)
    {
        return Vector3.Distance(position, other.position);
    }

    public static float Distance(NavQuad a, NavQuad b)
    {
        return a.Distance(b);
    }

    public bool IsImpassable()
    {
        return false;
    }
}
