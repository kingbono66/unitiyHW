using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour {
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    public bool isGameover = false; // 게임 오버 상태
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화 할 UI 게임 오브젝트

    private int score = 0; // 게임 점수
    private ScrollingObject[] scrollingObject;
    private float windPower;
    private float windPowerX;
    private float windPowerY;
    private float windDirection;
    private float baseGravity;
    private Text windPowerText;
    private Image windVaneImg;
    private bool temp = true;

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake() {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
            InitializeGame();
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if ((int)Time.time % 5 == 0 && temp)
        {
            SetWindEffect();
            temp = false;
        }
        else if ((int)Time.time % 5 == 1)
            temp = true;


    }
    private void InitializeGame()
    {
        scrollingObject = FindObjectsOfType<ScrollingObject>();
        windPowerText = GameObject.Find("WindPowerText").GetComponent<Text>();
        windVaneImg = GameObject.Find("WindVaneImage").GetComponent<Image>();
        Physics2D.gravity = new Vector2(0, -20f);
        baseGravity = Physics2D.gravity.y;
        SetWindEffect();
        
    }

    private void SetWindEffect()
    {
        windPower = UnityEngine.Random.Range(1.0f, 20.0f);
        windDirection = UnityEngine.Random.Range(0f, 360f);
        windPowerX = windPower * Mathf.Cos(windDirection * Mathf.PI / 180);
        windPowerY = windPower * Mathf.Sin(windDirection * Mathf.PI / 180); 
        Physics2D.gravity = new Vector2(0, baseGravity + windPowerY);
        windPowerText.text = windPower.ToString("F1") + " m/s";
        windVaneImg.transform.rotation = new Quaternion();
        windVaneImg.transform.Rotate(new Vector3(0, 0, windDirection - 90));
        SetScrollSpeed(windPowerX);
    }



    // 점수를 증가시키는 메서드
    public void AddScore(int newScore) {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead() {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void SetScrollSpeed(float speed)
    {
        foreach(ScrollingObject e in scrollingObject)
            e.SetScrollSpeed(speed);
    }
}