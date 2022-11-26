using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolarCell : MonoBehaviour
{
    int powerUnits = 100;
    List<GameObject> nodeArry;
    
    //Camera
    Camera cam;

    //Components
  
    GameObject mainObj;

    OperationOnTile tileManager;
    ModeManager modeManager;

    
    int index = 0;

    bool ButtonUpOnObject = false;
    public class Node
    {
        GameObject node;
    }
    // Start is called before the first frame update
    void Start()
    {
        nodeArry = new List<GameObject>();
        mainObj = GameObject.FindGameObjectWithTag("Main");

        
        

        cam = Camera.main;
        tileManager = mainObj.GetComponent<OperationOnTile>(); 
        modeManager = mainObj.GetComponent<ModeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeNode();
    }
    void MakeNode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 posRound = new Vector2((int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y));
            int key = tileManager.getKeyFromTilePos(posRound);
            if (!modeManager.ComponentsDict.ContainsKey(key))
            {
                return;
            }
            GameObject go = modeManager.ComponentsDict[key];
            if(go != transform.gameObject)
            {
                return;
            }
            ButtonUpOnObject = true;
        }
        
        if (Input.GetMouseButtonUp(0) && Input.GetKey(KeyCode.LeftShift) && ButtonUpOnObject)
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 posRound = new Vector2((int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y));
            int key = tileManager.getKeyFromTilePos(posRound);
            if (!modeManager.ComponentsDict.ContainsKey(key))
            {
                return;
            }
            GameObject go = modeManager.ComponentsDict[key];


            if (go == null)
            {
                return;
            }


            if (go.layer == LayerMask.NameToLayer("Mine"))
            {
                Miner mineComponent = go.GetComponent<Miner>();
                nodeArry.Add(go);
                LineRenderer lr = go.transform.GetComponent<LineRenderer>();
                lr.positionCount = 2;
                LineRender(lr, go.transform.position);
                if (powerUnits - mineComponent.powerUnit >= 0)
                {
                    powerUnits -= mineComponent.powerUnit;
                    mineComponent.PowerGetting = true;
                    
                   
                }
                //arrowRef = LineRenderer(arrow, transform.position, next.transform.position - transform.position);
                
            }
            
            else if (go.layer == LayerMask.NameToLayer("Sink"))
            {
                Sink sinkComponent = go.transform.GetComponent<Sink>();
                nodeArry.Add(go);
                LineRenderer lr = go.GetComponent<LineRenderer>();
                lr.positionCount = 2;
                LineRender(lr, go.transform.position);
                if (powerUnits - sinkComponent.powerUnit >= 0)
                {
                    powerUnits -= sinkComponent.powerUnit;
                    sinkComponent.PowerGetting = true;
                    
                    
                }
                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ButtonUpOnObject = false;
        }
    }
    public void LineRender(LineRenderer lineRenderer,Vector2 pos)
    {   
        lineRenderer.SetPosition(0,pos);
        lineRenderer.SetPosition(1, transform.position);

    }
    
}
