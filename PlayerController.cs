using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if( transform.position.x > -8)
                transform.Translate(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if( transform.position.x < 8)
                transform.Translate(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if( transform.position.y < 3.5)
                transform.Translate(0, speed, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if( transform.position.y > -3.5)
                transform.Translate(0, -speed, 0);
        }
    }
}
