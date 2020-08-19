using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotateSpeed = 60f;
    private float flexibilityX = -0.1f;
    private float flexibilityZ = -0.07f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        transform.localScale = new Vector3(transform.localScale.x + flexibilityX * Time.deltaTime,
            transform.localScale.y, transform.localScale.z + flexibilityZ * Time.deltaTime);
        if (transform.localScale.x < 0.5f || transform.localScale.x > 1)
            flexibilityX = -flexibilityX;
        if (transform.localScale.z < 0.5f || transform.localScale.z > 1)
            flexibilityZ = -flexibilityZ;

    }
}
