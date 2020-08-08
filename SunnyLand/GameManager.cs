using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SunnyLand.Constants;

public class GameManager : MonoBehaviour
{
    public GameObject cherryPrefab;    
    private Vector3[] cherryPos;
    public int CherryNum { get; private set; }
    private float currentTime;
    private new CameraController camera;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCherry();
        CherryNum = 0;
        currentTime = 0;
        camera = FindObjectOfType<CameraController>();
        GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(transform.right * 800);
        GameObject.Find("Player").GetComponent<Animator>().SetTrigger("RunTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 2) return;
        currentTime += Time.deltaTime;
        camera.MoveCamera(0.06f, 0.035f, 0.035f);
    }

    private void GenerateCherry()
    {
        cherryPos = new Vector3[MAX_CHERRY];
        cherryPos[0] = new Vector3(6.72f, -1.47f, 0);
        cherryPos[1] = new Vector3(-7.96f, -0.18f, 0);
        cherryPos[2] = new Vector3(3.91f, 3.05f, 0);
        cherryPos[3] = new Vector3(0.3f, -4.18f, 0);
        foreach (Vector3 pos in cherryPos)
        {
            GameObject cherry = GameObject.Instantiate(cherryPrefab);
            cherry.transform.position = pos;
        }        
    }

    public void IncreaseCherry()
    {
        CherryNum++;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "X " + CherryNum;
    }
}
