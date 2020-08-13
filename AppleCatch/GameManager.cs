using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private delegate void SetDifficulty();
    private Text timeText, pointText, resultText;
    private float time = 25f;
    private int point = 0;
    private bool isPlaying = false;
    private GameObject resultUI;
    private ItemGenerator itemGenerator;
    private SetDifficulty setDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        pointText = GameObject.Find("PointText").GetComponent<Text>();
        resultText = GameObject.Find("ResultText").GetComponent<Text>();
        itemGenerator = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
        resultUI = GameObject.Find("ResultText");
        resultUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            if (time <= 0)
                FinishGame();
            setDifficulty();
            time -= Time.deltaTime;
            timeText.text = time.ToString("F1");
            pointText.text = point.ToString() + " Point";
        }
    }

    private void SetDifficultyTime()
    {
        if (time >= 20)
            itemGenerator.SetCoef(1.0f);
        else if (time >= 10)
            itemGenerator.SetCoef(1.3f);
        else if (time >= 5)
            itemGenerator.SetCoef(1.5f);
        else if (time >= 0)
            itemGenerator.SetCoef(1.2f);
    }
    private void SetDifficultyPoint()
    {
        switch((int)point/100)
        {
            case 0: 
            case 1: itemGenerator.SetCoef(1.0f); break;
            case 2: 
            case 3: itemGenerator.SetCoef(2.5f); break;
            case 4:
            case 5: itemGenerator.SetCoef(4.0f); break;
            case 6:
            case 7: itemGenerator.SetCoef(7.5f); break;
            case 8:
            default: itemGenerator.SetCoef(20.0f); break;
        }
    }

    private void FinishGame()
    {
        GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().SetFinishGame();
        resultUI.SetActive(true);
        isPlaying = false;
        resultText.text = point.ToString() + "점 입니다";
    }

    public void GetApple()
    {
        if(isPlaying)
            point += 100;
    }
    public void GetBomb()
    {
        if (isPlaying)
            point /= 2;
    }
    public void OnTimeModeButtonDown()
    {
        setDifficulty = new SetDifficulty(SetDifficultyTime);
        GameStart();
    }
    public void OnPointModeButtonDown()
    {
        setDifficulty = new SetDifficulty(SetDifficultyPoint);
        GameStart();
    }
    public void GameStart()
    {
        isPlaying = true;
        GameObject.Find("TimeModeButton").SetActive(false);
        GameObject.Find("PointModeButton").SetActive(false);
        GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>().GameStart();
    }
}
