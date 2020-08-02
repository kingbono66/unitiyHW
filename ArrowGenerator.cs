using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    private float span;
    private float delta;

    // Start is called before the first frame update
    void Start()
    {
        span = 1.0f;
        delta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if( delta > span)
        {
            delta = 0;
            GameObject newArrow = Instantiate(arrowPrefab);
        }
    }
}
