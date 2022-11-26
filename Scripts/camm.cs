using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class camm : MonoBehaviour
{
    public CinemachineVirtualCamera m_Camera;
    int zoomInButton = 3;int zoomOutButton = 4; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(zoomOutButton))
        {
            
            m_Camera.m_Lens.OrthographicSize += 1;
        }
        else if (Input.GetMouseButtonDown(zoomInButton))
        {
            m_Camera.m_Lens.OrthographicSize -= 1;
        }
        m_Camera.m_Lens.OrthographicSize = Mathf.Clamp(m_Camera.m_Lens.OrthographicSize, 4, 12);
    }
}
