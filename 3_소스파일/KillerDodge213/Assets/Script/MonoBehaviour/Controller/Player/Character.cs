using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
  

    public float maxHitPoints;
    public float LevelPoints; // 시간 안될꺼 같으면 빼자 

    public float startingHitPoints;

    public float LevelBar;
    public float Startlevel;

    public float Droplevel;

    public float Maxlevel = 100;

 

    public abstract IEnumerator DamageCharacter(int damage, float interval);
  
    public virtual void KillerCharacter()
    {
        Destroy(gameObject);
    }

    
    // 죽으면 떨어뜨리는 경험치 양
    /// <summary>
    /// 플레이어와 다양한 적들을 처리하기 위한 부모 클래스 입니다.
    /// 각각 다른 성질을 설정할 생각이기에 추상화 하여 필요 부분들을 자식 클래스에서 통제하려고 만든 스크립트입니다.
    /// 
    /// </summary>

    
     
}
