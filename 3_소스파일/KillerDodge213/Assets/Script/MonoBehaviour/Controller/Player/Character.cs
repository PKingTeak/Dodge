using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour 
{
    GameManager gamemanager;
    public float maxHitPoints;
    

    public float startingHitPoints;
    public abstract IEnumerator DamageCharacter(int damage, float interval);
  
    public virtual void KillerCharacter()
    {
        Destroy(gameObject);
        
    }

    public void Die() 
    {
        
        gameObject.SetActive(false); 
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
        // 이건 플레이어가 HP 가 0 일때
    }
     
}
