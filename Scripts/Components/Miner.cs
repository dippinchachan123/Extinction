using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField]
    GameObject seed;
    Vector2[] PipePosArry;

    //
    
    ModeManager modeManager;
    
    OperationOnTile tilemanager;
    //timedifference of seed in miner
    [SerializeField]
    float timed;

    //Timedelay
    float timec = 0;

    //PowerUnits require
    [HideInInspector]
    public int powerUnit = 2;
    [HideInInspector]
    public bool PowerGetting = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mn = GameObject.FindGameObjectWithTag("Main");
        modeManager = mn.GetComponent<ModeManager>();
        tilemanager = mn.GetComponent<OperationOnTile>();   
        Vector2 pos = transform.position;   
        PipePosArry = new Vector2[8];
        PipePosArry[0] = pos + new Vector2(0.5f,1.5f);
        
        PipePosArry[1] = pos + new Vector2(-0.5f, 1.5f);
        
        PipePosArry[2] = pos + new Vector2(0.5f, -1.5f);
        
        PipePosArry[3] = pos + new Vector2(-0.5f, -1.5f);
        
        PipePosArry[4] = pos + new Vector2(1.5f, 0.5f);

        PipePosArry[5] = pos + new Vector2(1.5f, -0.5f);

        PipePosArry[6] = pos + new Vector2(-1.5f, 0.5f);

        PipePosArry[7] = pos + new Vector2(-1.5f, -0.5f);

    }
    // Update is called once per frame
    void Update()
    {
       if(timec > timed)
        {
            CheckPipeTile();
            timec = 0;
        }
        timec += Time.deltaTime;
    }
    void CheckPipeTile()
    {
        for(int i = 0; i < PipePosArry.Length; i++)
        {
            
           
            if (modeManager.ComponentsDict.ContainsKey(tilemanager.getKeyFromTilePos(PipePosArry[i]))){
                
                GameObject go = modeManager.ComponentsDict[tilemanager.getKeyFromTilePos(PipePosArry[i])];
                if(go.layer == LayerMask.NameToLayer("Pipe"))
                {
                    seeding(go);
                }
            }
        }
    }
    /*void printDict(Dictionary<int,GameObject> dict)
    {
        foreach(KeyValuePair<int,GameObject> pair in dict)
        {
            print("key : " + pair.Key + " value:" + pair.Value);
        }
    }*/

    void seeding(GameObject pipe)
    {
        if (PowerGetting) {
            GameObject go = Instantiate(seed, pipe.transform.position, Quaternion.identity);
            go.GetComponent<Seed>().sprite = seed.GetComponent<SpriteRenderer>().sprite;
            go.GetComponent<Seed>().value = 10;
            go.GetComponent<Seed>().seedType = SeedType.Gold;
            pipe.GetComponent<Pipe>().seed = go;
        }
        
    }
    
}