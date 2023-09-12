using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class M_MenuUI : MonoBehaviour
{
    public GameObject stage;

private void Start() 
{
    
    
}
    
    void ChangeSceneBtn()
    {
        switch(this.gameObject.name)
        {
        case "B_Start ":
        stage.SetActive(true);
        
        break;
        case "Btn_Stage1" :
        SceneManager.LoadScene("Dodge_C");
        break;
        


        }
    }
    ///<summary>
    ///메인 화면에서 게임을 시작했을때 버튼을 눌렀을때 씬 전환을 위해 만든 매서드 입니다.
    ///stage를 추가하여 각 스테이지마다 난이도를 조절하려 하였으나 stage 1만 구현한 상태입니다.
    /// </summary>
    
}
