using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    Dictionary<SeedType,int> dict = new Dictionary<SeedType, int>();//Amount of minerals

    //powerRequired
    [HideInInspector]
    public int powerUnit = 0;
    [HideInInspector]
    public bool PowerGetting = false;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Dictionary<SeedType,int> GetDict()
    {
        return dict;    
    }
}
