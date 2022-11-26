using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    int modeIndexCurrent = 0;
    public Mode[] modes;
    OperationOnTile tileManager;
    UICheck uiCheck;
    Dictionary<int, Mode> modeDict;
    public Dictionary<int, GameObject> ComponentsDict = new Dictionary<int, GameObject>();  


    [System.Serializable]
    public class Mode
    {
        public int modeIndex;public int modeTiles;public string modeName;public string tileOrientation;
        public GameObject go;
        public Mode(int modeIndex, int modeTiles, string modeName, string tileOrientation)
        {
            this.modeIndex = modeIndex;
            this.modeTiles = modeTiles;
            this.modeName = modeName;
            this.tileOrientation = tileOrientation;
        }
    }
    
    // Start is called before the first frame update
    
    void Start()
    {
        tileManager = GetComponent<OperationOnTile>(); 
        uiCheck = GetComponent<UICheck>();  
        modeDict = new Dictionary<int, Mode>();
        for(int i = 0; i < modes.Length; i++)
        {
            modeDict[modes[i].modeIndex] = modes[i];
        }
    }
    void Update()
    {

        switch (modeIndexCurrent)
        {
            case 0:
                {
                    ModeRelax();
                    break;
                }
            case 1:
                {
                    ModeMine();
                    break;
                }
            case 2:
                {
                    ModePipe();
                    break;
                }
            case 3:
                {
                    ModeSink();
                    break;
                }
            case 4:
                {
                    ModeSolarCell();
                    break;
                }
            case 5:
                {
                    ModeInputCell();
                    break;
                }


            case 6:
                {
                    ModeOutputCell();
                    break;
                }
        }
    }


    public void ChangeModeIndexToZero()
    {
        modeIndexCurrent = 0;
    }
    public void ChangeModeIndexToOne()
    {
        modeIndexCurrent = 1;
    }
    public void ChangeModeIndexToTwo()
    {
        modeIndexCurrent = 2;
    }
    public void ChangeModeIndexToThree()
    {
        modeIndexCurrent = 3;
    }
    public void ChangeModeIndexToFour()
    {
        modeIndexCurrent = 4;
    }
    public void ChangeModeIndexToFive()
    {
        modeIndexCurrent = 5;
    }
    public void ChangeModeIndexToSix()
    {
        modeIndexCurrent = 6;
    }

    // Update is called once per frame


    public GameObject[] modeTile1()
    {

        GameObject[] tileArry = tileManager.SelectTilesUnderMouse(1);
        if (tileArry[0].layer != LayerMask.NameToLayer("PlanetSurface"))
        {
            return null;
        }
        if(tileArry != null)
        {
            tileManager.HighlightTileArry(tileArry);
        }
        return tileArry;
    }
    public GameObject[] modeTile2()
    {
        GameObject[] tileArry = tileManager.SelectTilesUnderMouse(2);
        if (tileArry != null)
        {
            tileManager.HighlightTileArry(tileArry);
        }
        return tileArry;
    }
    public GameObject[] modeTile3()
    {
        GameObject[] tileArry = tileManager.SelectTilesUnderMouse(2,"Vertical");
        if (tileArry[0].layer != LayerMask.NameToLayer("PlanetSurface"))
        {
            return null;
        }
        if (tileArry != null)
        {
            tileManager.HighlightTileArry(tileArry);
        }
        return tileArry;
    }
    public GameObject[] modeTile4()
    {
        GameObject[] tileArry = tileManager.SelectTilesUnderMouse(4);
        if (tileArry[0].layer != LayerMask.NameToLayer("PlanetSurface"))
        {
            return null;
        }
        if (tileArry != null)
        {
            tileManager.HighlightTileArry(tileArry);
        }
        return tileArry;
    }
    public void ModeRelax()
    {
        
    }
    public void ModeGenerator(GameObject[] tiles,Vector3 offset,int ModeIndex,string layerName)
    {
        if (tiles == null || tiles[0].GetComponent<SpriteRenderer>().color == Color.red)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && !uiCheck.IsPointerOverUIElement())
        {
            Vector3 vec = tiles[0].transform.position + offset;
            GameObject Obj = Instantiate(modeDict[ModeIndex].go, vec, Quaternion.identity);
            for (int i = 0; i < tiles.Length; i++)
            {
                TileBehaviour tileBehav = tiles[i].GetComponent<TileBehaviour>();
                tileBehav.onTop = Obj;
                ComponentsDict.Add(tileBehav.TileValue, Obj);
            }

            for (int i = 0; i < tiles.Length; i++)
            {
                GameObject tile = tiles[i];
                tile.layer = LayerMask.NameToLayer(layerName);
            }
        }
    }
    public void ModeMine()
    {
        GameObject[] tiles = modeTile4();
        ModeGenerator(tiles, new Vector3(0.5f, -0.5f, -10), 1, "Mine");
    }
    public void ModePipe()
    {
        GameObject[] tiles = modeTile1();
        ModeGenerator(tiles, new Vector3(0, 0, -10), 2, "Pipe");
    }
    public void ModeSink()
    {
        GameObject[] tiles = modeTile4();
        ModeGenerator(tiles, new Vector3(0.5f, -0.5f, -10), 3, "Sink");
        
    }
    public void ModeSolarCell()
    {
        GameObject[] tiles = modeTile4();
        ModeGenerator(tiles, new Vector3(0.5f, -0.5f, -10),4, "SolarCell");
        
    }
    public void ModeInputCell()
    {
        GameObject[] tiles = modeTile4();
        ModeGenerator(tiles, new Vector3(0.5f, -0.5f, -10), 5, "InputCell");
        
    }
    public void ModeOutputCell()
    {
        GameObject[] tiles = modeTile4();
        ModeGenerator(tiles, new Vector3(0.5f, -0.5f, -10), 6, "OutputCell");
        
    }

}
