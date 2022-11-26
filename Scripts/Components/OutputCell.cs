using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputCell : MonoBehaviour
{
    int v;
    // Start is called before the first frame update
    private void Start()
    {
        v = Random.RandomRange(0, 2);
    }
    public void ChangeColor()
    {
        if(v == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (v == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        
    }
}
