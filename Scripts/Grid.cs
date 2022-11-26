using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Grid
{
    public string Name;
    public GameObject tile;
    public LayerMask LayerMask;
    public GameObject parent;
    public int x; public int y;public int tilesCount;public int tileSize;

    public Dictionary<int, GameObject> tilesDict;
    public Grid(int x,int y,int tileS)
    {
        int tileX = x; int tileY = y;int tileSize = tileS;
    }
}
