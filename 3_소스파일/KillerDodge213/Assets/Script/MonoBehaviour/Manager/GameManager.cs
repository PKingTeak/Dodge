using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;







public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    



    public GameObject gameoverText;
    public Text timeText;

    public Text recodetime;
    public Text scoreText;
    public int score = 0;
    
  
    private float surviveTime;
    private bool isGameover;
   
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }
        
    }
    
    void Start()
    {//스타트는 한번만 실행 되는데 이곳으로 하는이유 플레이할때 없어지고 사망하면 생기니까 나올때마다 스타트가 생긴다.
        surviveTime = 0; // 생존 시간을 측정하기 위한 변수
        isGameover = false;
       

    }

    
    void Update()
    {       
        if(!isGameover)
        {
            surviveTime += Time.deltaTime; // 생존시간 변수에 시간 넣는다
            timeText.text = ("Time: " + (int)surviveTime); // 생존시간 텍스트 변수선언한거 .속성값(컴포에서 할껏 무조건 시작소문자)

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Dodge_C");
            }
        }
        
    }
    

    /// <summary>
    /// 게임 종료시 매서드
    /// 게임 오버라는 텍스트 출력
    /// 가장 오래 버틴시간을 출력해주고
    /// 생존 시간을 표시합니다
    /// </summary>
    
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
    


        if(surviveTime > bestTime)
        {
           bestTime = surviveTime;
           PlayerPrefs.SetFloat("BestTime",bestTime);

        }
        recodetime.text = "BestTime: " + (int)bestTime;
      
    }

/// <summary>
/// 게임도중 점수를 얻게 되는 점수를 저장하는 메서드 입니다. 
/// </summary>

    
    public void AddScore(int newScore)
{
    if(!isGameover)
    {
        score += newScore;
        scoreText.text = "Score :" + score;
        
    }
    
}


    
}


