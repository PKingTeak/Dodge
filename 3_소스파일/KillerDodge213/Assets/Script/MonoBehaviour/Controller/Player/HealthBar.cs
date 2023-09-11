using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoints hitPoints;
    
     //코드에서는 쓰지만 유니티 엔진에서는 안보여줌
     [HideInInspector]
    public PlayerController character; //Null 체크  

    public Image HPBar;
    public Text hpText;

    float maxHitPoints;
    // Start is called before the first frame updateW
    void Start()
    {
        maxHitPoints = character.maxHitPoints;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(character != null)
        {
            
            HPBar.fillAmount = hitPoints.value / maxHitPoints;
            

            hpText.text = "HP:" + (HPBar.fillAmount * 100); // 퍼센트로 표시하기 위함

        }
        
    }
}
