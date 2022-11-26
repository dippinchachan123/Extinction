using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class OperationOnTile : MonoBehaviour
{
    GridManager gridManager;
    Grid[] grids;
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject HighlightedTile;
    [SerializeField]
    Transform HighlTilesParent;
    //PreviousMousePos
    Vector2 prevMousePos;
    GameObject[] prevTilesArry;

    //HighlightObj Array
    GameObject[] HighlTilesObjArry;
    // Start is called before the first frame update
    void Start()
    {
        
        gridManager = GetComponent<GridManager>();
        grids = gridManager.grids;
    }

    // Update is called once per frame
    
    public bool TilesEmptyViaPos(Vector2[] posArry)
    {
        Grid grid = grids[0];
        for (int i = 0; i < posArry.Length; i++)
        {
            GameObject go = GetTileViaPos(posArry[i]);
            if (go == null || go.layer != LayerMask.NameToLayer("PlanetSurface"))
            {
                return false;
            }
        }
        return true;
    }
    public bool TilesEmptyViaGameObject(GameObject[] tiles)
    {
        Grid grid = grids[0];
        for (int i = 0; i < tiles.Length; i++)
        {
            GameObject go = tiles[i];
            if (go == null || go.layer != LayerMask.NameToLayer("PlanetSurface"))
            {
                return false;
            }
        }
        return true;
    }
    
    public GameObject[] SelectTilesUnderMouse(int tileCount,string Orientation = "Horizontal")
    {

        GameObject[] tiles = new GameObject[tileCount];

        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 posRound = new Vector2((int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y));

        if(prevTilesArry != null)
        {
            HighlightTileArry(prevTilesArry, -1);
        }
        
        switch (tileCount)
        {
            case 1:
                tiles[0] = GetTileViaPos(pos);
                break;
            case 2:
                if(Orientation == "Horizontal")
                {
                    tiles[0] = GetTileViaPos( pos);
                    tiles[1] = GetTileViaPos(pos + new Vector2(1,0));
                }
                if (Orientation == "Vertical")
                {
                    tiles[0] = GetTileViaPos(pos);
                    tiles[1] = GetTileViaPos(pos + new Vector2(0, 1));
                }
                break;
            case 4:
                tiles[0] = GetTileViaPos(pos);
                tiles[1] = GetTileViaPos(pos + new Vector2(1, 0));
                tiles[2] = GetTileViaPos(pos + new Vector2(0, -1));
                tiles[3] = GetTileViaPos(pos + new Vector2(1, -1));
                break;
        }
        prevTilesArry = tiles;
        prevMousePos = posRound;
        return tiles;
    }
    public GameObject GetTileViaPos(Vector2 mousePos)
    {
        Grid grid = grids[0];
        int[] arry = {(int) Mathf.Round(mousePos.x),(int) Mathf.Round(mousePos.y)};
        if (grid.tilesDict.ContainsKey(arry[1] + (grid.tilesCount * arry[0])))
        {
            return grid.tilesDict[arry[1] + (grid.tilesCount * arry[0])];
        }
        return null;
    }
    public GameObject[] GetTilesViaPos(Vector2[] mousePosarry)
    {
        Grid grid = grids[0];
        if (mousePosarry[0] == null)
        {
            return null;
        }
        GameObject[] tileArry = new GameObject[mousePosarry.Length];
        for(int i = 0; i < grid.tilesCount; i++)
        {
            tileArry[i] = GetTileViaPos(mousePosarry[i]);
        }
        return tileArry;
        
    }
    

    public void errorAllTiles(GameObject[] HtilesArry)

    {
        if(HtilesArry == null)
        {
            return; 
        }
        for (int i = 0; i < HtilesArry.Length; i++)
        {
            if (HtilesArry[i] == null)
            {
                continue;
            }

            GameObject obj = HtilesArry[i].GetComponent<TileBehaviour>().onTop; 
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;
        }

    }
    public void HighlightTileArry(GameObject[] tiles,int highlight = 1)
    {
        for(int i = 0; i < tiles.Length; i++)
        {
            int tileNotNull = HighlightTileViaObject(tiles[i], highlight);
            if(tileNotNull == 0) {
                errorAllTiles(tiles);
                break;
            }
        }
    }

    public int HighlightTileViaObject(GameObject tile, int highlight = 1)//For unhighlight highlight = -1; 
    {
        if (highlight == -1)
        {
            if (tile == null)
            {
                return 1;
            }
            Destroy(tile.GetComponent<TileBehaviour>().onTop);
        }
        else if (tile == null || tile.layer != LayerMask.NameToLayer("PlanetSurface"))
        {

            GameObject go = Instantiate(HighlightedTile, tile.transform.position, Quaternion.identity, HighlTilesParent);
            return 0;
        }
        else
        {
            GameObject go = Instantiate(HighlightedTile, tile.transform.position, Quaternion.identity, HighlTilesParent);
            tile.GetComponent<TileBehaviour>().onTop = go;
        }
        return 1;
    }



}
