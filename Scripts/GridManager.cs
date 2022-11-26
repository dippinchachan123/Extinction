using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;


public class GridManager:MonoBehaviour
{
    public int x;

    [SerializeField]

    public Grid[] grids;

    //Camera

    [SerializeField]

    Transform cam;

    //Dictionary of Tiles;

    public void GridGenerator(Grid grid)
    {
        
        int tileWidth = grid.tilesCount;
        for(int r = 0; r < tileWidth; r++)
        {
            for(int c = 0; c < tileWidth; c++)
            {
                GameObject go = Instantiate(grid.tile, new Vector3(r + grid.x, c + grid.y, 0),Quaternion.identity,grid.parent.transform);
                go.layer = Mathf.RoundToInt(Mathf.Log(grid.LayerMask.value, 2));
                print(go.layer);
                int[] arry = { c + grid.x, r + grid.y };
                
                grid.tilesDict.Add(arry[0] + (grid.tilesCount * arry[1]), go); 
            }
        }
    }
    public void Start()
    {
        for (int i = 0; i < grids.Length; i++)
        {
            /*if (grids[i].Name == "PlanetSurface")
            {
                Vector3 vec = new Vector3(grids[i].x + (grids[i].tilesCount * grids[i].tileSize) / 2, grids[i].y + (grids[i].tilesCount * grids[i].tileSize) / 2, -10);
                cam.position = vec;
            }*/
            grids[i].tilesDict = new Dictionary<int, GameObject>();
            GridGenerator(grids[i]);
            
           
        }
    }
    
    private void Update()
    {
        
    }

}
