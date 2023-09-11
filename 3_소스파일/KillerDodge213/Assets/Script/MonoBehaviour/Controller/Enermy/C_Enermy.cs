using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Enermy : Character
{

    // 근접 공격 하는 적
    private Transform target;
     public float hitPoints;
     public  int damageStrength;
     Coroutine damageCoroutine; 
     


    
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while(true)
        {
            hitPoints = hitPoints - damage;

            if(hitPoints <= float.Epsilon)
            {
                KillerCharacter(); 
                GameManager.Instance.AddScore(2);
            }   
            if(interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }

            else
            {
            break;
            }
            //인터벌 계산 데미지 추가.
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
        
            if(damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength,1.0f));
                // 캐릭터 한테 붙었을때 데미지 주기 
            }
        }

        
        
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
        
    }
}
