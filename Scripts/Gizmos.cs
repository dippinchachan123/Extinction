using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gizmos : MonoBehaviour
{
    Dictionary<int,GameObject> tileDict;
    bool visibility = true;
    bool DrawDone = false;

    // Start is called before the first frame update
    void Start()
    {
       
          
    }
    void ToogleVisibility()
    {
        tileDict = GetComponent<GridManager>().grids[0].tilesDict;
        visibility = !visibility;
        
        for (int i = 0; i < tileDict.Count; i++)
        {
            tileDict[i].GetComponent<SpriteRenderer>().enabled = visibility;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           ToogleVisibility();  
        }
    }
    /*private void OnDrawGizmos()
    {
            for (int r = 0; r < 100; r++)
            {
                for (int c = 0; c < 100; c++)
                {
                    Rect rect = new Rect(r - 0.5f, c - 0.5f, 1, 1);
                    Handles.DrawSolidRectangleWithOutline(rect, Color.clear, Color.blue);
                    Handles.Label(new Vector2(c - 0.3f, r), ((100 * r) + c).ToString());
                }
            }
    }*/
}
