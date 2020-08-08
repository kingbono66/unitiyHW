using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(float x, float y, float size)
    {
        if((int)(transform.position.x*100) == 0 )
            transform.position = new Vector3(0, 0, -10);
        else
            transform.Translate(x, y, 0);
        if (GetComponent<Camera>().orthographicSize < 5)
            GetComponent<Camera>().orthographicSize += size;
        else
            GetComponent<Camera>().orthographicSize = 5;
    }
}
