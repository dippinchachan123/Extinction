using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputCell : MonoBehaviour
{
    
    string TextInput;

    GameObject[] outputsCells;

    OperationOnTile tilemanager;
    GridManager gridmanager;

    //Toogle 
    bool toogle = false;
    // Start is called before the first frame update
    void Start()
    {
        outputsCells = GameObject.FindGameObjectsWithTag("OC");
        GameObject go = GameObject.FindGameObjectWithTag("Main");
        tilemanager = go.GetComponent<OperationOnTile>();   
        gridmanager = go.GetComponent<GridManager>();   

       
        
    }

    // Update is called once per frame
    void Update()
    {
        SetActiveFalse();
        OpenInputTextField(transform);
        
        
    }
    void OpenInputTextField(Transform t)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            
        }
    }
    void SetActiveFalse()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   
        {
            SceneManager.UnloadScene(1);
            Time.timeScale = 1;
            for(int i = 0; i < outputsCells.Length; i++)
            {
                if(InputText.textid == 0)
                {
                    outputsCells[i].GetComponent<OutputCell>().ChangeColor();
                }
                if(InputText.textid == 1)
                {
                    GameObject tile = tilemanager.GetTileViaPos(gridmanager.grids[0], transform.position);
                    tile.GetComponent<TileBehaviour>().seeding = true;
                }
            }
        }
    }
    
}
