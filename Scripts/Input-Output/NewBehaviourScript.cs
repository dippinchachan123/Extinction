using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int i = 0;int j = 0;
    string text;
    Sprite[] output;

    Dictionary<string, string> script = new Dictionary<string, string>();
    Dictionary<string, int> compiler = new Dictionary<string,int>();

    public GameObject canvas;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i > 4)
        {
            i = 0;
            j++;
        }
    }
    public void A()
    {
        Instantiate(gameObjects[0],new Vector3((i*120) + 190 ,900 - (120*j),-10),Quaternion.identity,canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void B()
    {

        Instantiate(gameObjects[1], new Vector3((i * 120) + 190 , 900 - (120 * j), -10), Quaternion.identity,canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void C()
    {

        Instantiate(gameObjects[2], new Vector3((i * 120) + 190 , 900 - (120 * j), -10), Quaternion.identity,canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void D()
    {

        Instantiate(gameObjects[3], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
        print("gggg");
        InputText.textid = 1;
    }
    public void E()
    {

        Instantiate(gameObjects[4], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void F()
    {

        Instantiate(gameObjects[5], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void G()
    {

        Instantiate(gameObjects[6], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void H()
    {

        Instantiate(gameObjects[7], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }
    public void I()
    {

        Instantiate(gameObjects[8], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        //Instantiate(gameObjects[0], new Vector3((i * 120) + 190, 900 - (120 * j), -10), Quaternion.identity, canvas.transform);
        i++;
    }


}
