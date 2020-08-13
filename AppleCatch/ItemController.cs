using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private float baseSpeed = -0.005f;
    private float changedSpeed = -0.005f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, changedSpeed, 0);
        if (transform.position.y < -1f)
            Destroy(gameObject);
    }
    public void SetDropSpeed(float coefficient) => changedSpeed = baseSpeed * coefficient;
}
