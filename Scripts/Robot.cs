using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Vector3 faceDirec;
    [SerializeField]
    float speed = 0;
    Vector3 vel = Vector3.zero;Vector3 accForward;Vector3 accNegative;
    [SerializeField]
    float resistance;
    [SerializeField]
    float rotationalSensitivity;
    Vector3 pos;



    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3 (10, 10,-10);
        faceDirec = new Vector3(0, 1,0);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        faceDirec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if(faceDirec != Vector3.zero) 
        {
            quaternion lookrotation = Quaternion.LookRotation(Vector3.forward, faceDirec);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookrotation, rotationalSensitivity * Time.deltaTime);

        }
        int axisValue =(int) Mathf.Pow(math.pow(Input.GetAxis("Horizontal"), 2) + math.pow(Input.GetAxis("Vertical"), 2), 0.5f);
        accForward = faceDirec * axisValue * speed;
        accNegative = -vel * resistance;
        vel += (accForward + accNegative) * Time.deltaTime;
        pos += vel * Time.deltaTime;
        transform.position = pos;
    }
   
}
