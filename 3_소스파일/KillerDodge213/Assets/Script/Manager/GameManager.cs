using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;







public class GameManager : MonoBehaviour
{
    
    public GameObject gameoverText;

    
    
    public Text timeText;

    public Text recodetime;
    public Text scoreText;
    public int score = 0;
    
  
    private float surviveTime;
    private bool isGameover;
   
    void Start()
    {//스타트는 한번만 실행 되는데 이곳으로 하는이유 플레이할때 없어지고 사망하면 생기니까 나올때마다 스타트가 생긴다.
        surviveTime = 0;
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
    

    //게임오버
    
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
        Debug.Log("시간이 증가합니다.");
    }


    //점수 추가 클래스
    
    public void AddScore(int newScore)
{
    if(!isGameover)
    {
        score += newScore;
        scoreText.text = "Score :" + score;
        Debug.Log("점수가 증가합니다.");
    }
    
}
    
}


