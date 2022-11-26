using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Pipe : MonoBehaviour
{
    GameObject next;
    Camera cam;
    OperationOnTile tileManager;
    ModeManager modeManager;

    //Arrow
    public GameObject arrow;float arrowRotationSpeed;
    GameObject arrowRef;
    [SerializeField]
    Sprite PipeGreen;
    //seed
    [HideInInspector]
    public GameObject seed;

    //Time
    [SerializeField]
    float timed;float timec = 0;

    bool NextFinding  = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        GameObject main = GameObject.FindGameObjectWithTag("Main");
        tileManager = main.GetComponent<OperationOnTile>(); 
        modeManager = main.GetComponent<ModeManager>(); 
    }
    // Update is called once per frame
    void Update()
    {
        if (!NextFinding)
        {
            NextFindStep1();
        }
        else
        {
            NextFindStep2();
        }
        if (timec > timed)
        {
            SeedTransfer();
            timec = 0;
        }
        timec += Time.deltaTime;
    }
    public void setSeed(GameObject go)
    {
        this.seed = go;
    }
    void NextFindStep2()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 posRound = new Vector2((int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y));
            int key = tileManager.getKeyFromTilePos(posRound);
            if (!modeManager.ComponentsDict.ContainsKey(key))
            {
                print("aaaaa");
                return;
            }
            GameObject go = modeManager.ComponentsDict[key];
            
            
            if(go == null)
            {
                return;
            }
            
            
            if(go.layer == LayerMask.NameToLayer("Pipe"))
            {
                if (!CheckSidePipeExist(go))
                {
                    return;
                }
                
                next = go;
                if (next != null)
                {
                    Destroy(arrowRef);
                }
                arrowRef = Arrow(arrow, transform.position, next.transform.position - transform.position);
                GetComponent<SpriteRenderer>().sprite = PipeGreen;
                NextFinding = false;
            }
            else if(go.layer == LayerMask.NameToLayer("Sink"))
            {
                next = go;
                if (next != null)
                {
                    Destroy(arrowRef);
                }
                arrowRef = Arrow(arrow, transform.position, next.transform.position - transform.position);
                GetComponent<SpriteRenderer>().sprite = PipeGreen;
                NextFinding = false;
            }
            





        }
    }
    GameObject Arrow(GameObject ar,Vector2 pos,Vector3 dir)
    {

        float angle = Vector2.SignedAngle(new Vector2(1,0),dir);
        Quaternion target = Quaternion.Euler(0, 0, angle);
        GameObject parent = GameObject.FindGameObjectWithTag("ArrowsContainer");
        GameObject go = Instantiate(ar, pos,Quaternion.identity,parent.transform);
        Quaternion rot = target;
        go.transform.rotation = rot;
        return go;
    }
    void NextFindStep1()
    {
        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 posRound = new Vector2((int)Mathf.Round(pos.x), (int)Mathf.Round(pos.y));

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0) && posRound.Equals(transform.position))
        {
            NextFinding = true;
        }
    }
    bool CheckSidePipeExist(GameObject pipenext) 
    {
        Vector2 posN = pipenext.transform.position;
        Vector2 pos = transform.position;
        Vector2 right = new Vector2(1, 0); Vector2 left = new Vector2(-1, 0);
        Vector2 up = new Vector2(0,1); Vector2 down = new Vector2(0,-1);
        if (posN.Equals(pos + right) || posN.Equals(pos + left) || posN.Equals(pos + up)|| posN.Equals(pos + down))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void SeedTransfer()
    {
        if(next != null)
        {
            if(next.layer == LayerMask.NameToLayer("Sink"))
            {
                if(seed != null)
                {
                    Seed sd = seed.GetComponent<Seed>();
                    if (!next.GetComponent<Sink>().GetDict().ContainsKey(sd.seedType))
                    {
                        next.GetComponent<Sink>().GetDict().Add(sd.seedType,1);
                    }
                    else
                    {
                        next.GetComponent<Sink>().GetDict()[sd.seedType] += 1;
                    }
                    Destroy(this.seed);
                }
                
            }
            else
            {
                Pipe nextPipe = next.GetComponent<Pipe>();
                if (seed != null && nextPipe.seed == null)
                {
                    Pipe go = next.GetComponent<Pipe>();
                    go.setSeed(this.seed); this.seed = null;
                    go.seed.transform.position = next.transform.position;
                }
            }
            
        }
        
        
    }

}
