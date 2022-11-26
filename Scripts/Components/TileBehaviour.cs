using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool seeding = false;
    //ObjectOnTop;
    [HideInInspector]
    public GameObject onTop;
    //TilesAway
    [HideInInspector]
    public GameObject left;
    [HideInInspector]
    public GameObject right;
    [HideInInspector]
    public GameObject up;
    [HideInInspector]
    public GameObject down;
    //
    //TilesAround Array
    GameObject[] tilesAround;
    [HideInInspector];
    public int TileValue;
    //TilesDIct
    public Dictionary<int, GameObject> tilesDict = new Dictionary<int, GameObject>();
    ///Delays <summary>
    /// Delays
    /// </summary>
    [SerializeField]
    float delay1;
    float timeC1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        delay1 = 2;

        left = getTilesAway(new Vector2(-1, 0));
        right = getTilesAway(new Vector2(+1, 0));
        up = getTilesAway(new Vector2(0, 1));
        down = getTilesAway(new Vector2(0, -1));
        
        tilesAround = new GameObject[4] { left, right, down, up };
       

        GameObject go = GameObject.FindGameObjectWithTag("Main");
        GridManager gridManager = go.GetComponent<GridManager>();

        tilesDict = gridManager.grids[0].tilesDict;
        TileValue = (int)(transform.position.y * 100) + (int)transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (seeding)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            if (Tools.TimeDelay(ref delay1,ref timeC1))
            {
                SeedEnvironment();
            }
        }
    }

    void SeedEnvironment()
    {
        
        for (int i = 0; i < 4; i++)
        {
            if (tilesAround[i] != null)
            {
                tilesAround[i].GetComponent<TileBehaviour>().seeding = true;
            }
        }
    }
    public GameObject getTilesAway(Vector2 vec)//give tile away from itself usnig displacement Vector;
    {
        int v = TileValue + (int)vec.x;
        v += (100 * (int)vec.y);
        if (tilesDict.ContainsKey(v))
        {
            return tilesDict[v];
        }
        return null;
    }

    
}
