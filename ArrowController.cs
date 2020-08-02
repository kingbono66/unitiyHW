using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArrowController : MonoBehaviour
{
    private float speed;
    private bool isXWay;
    private GameObject player;
    private const float minSpeed = 0.02f;
    private const float maxSpeed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Bonobono2");
        //속도,위치 랜덤 생성
        if (Random.Range(0, 2) == 0)
            isXWay = true;
        else
            isXWay = false;
        if (Random.Range(0, 2) == 0)
            speed = Random.Range(minSpeed, maxSpeed);
        else
            speed = -(Random.Range(minSpeed, maxSpeed));

        if (isXWay)
        {
            if (speed > 0)
            {
                transform.position = new Vector3(-10f, Random.Range(-4f, 4f), 0);
                transform.Rotate(0, 0, 90f);
            }
            else
            {
                transform.position = new Vector3(10f, Random.Range(-4f, 4f), 0);
                transform.Rotate(0, 0, 270f);
            }
        }
        else
        {
            if (speed > 0)
            {
                transform.position = new Vector3(Random.Range(-8f, 8f), -6f, 0);
                transform.Rotate(0, 0, 180f);
            }
            else
                transform.position = new Vector3(Random.Range(-8f, 8f), 6f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isXWay)
        {
            if (speed > 0)
                transform.Translate(0, -speed, 0);
            else
                transform.Translate(0, speed, 0);
        }
        else
        {
            if (speed > 0)
                transform.Translate(0, -speed, 0);
            else
                transform.Translate(0, speed, 0);
        }

        if ((transform.position - player.transform.position).magnitude < 1.5) // arrow 0.5   bonobono 1
        { 
            GameObject.Find("GameManager").GetComponent<GameManager>().DecreaseHP();
            Destroy(gameObject);
        }

        if((isXWay && math.abs((int)transform.position.x) > 12)         //화면밖으로 나가면 삭제
            || (!isXWay && math.abs((int)transform.position.y) > 8))
            Destroy(gameObject);
    }

   
}
