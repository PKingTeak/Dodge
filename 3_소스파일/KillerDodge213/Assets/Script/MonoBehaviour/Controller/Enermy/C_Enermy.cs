using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Enermy : Character
{
     public float hitPoints;
     public  int damageStrength;

    public PlayerController player;
     public GameObject enermy;

    
    
    Coroutine damageCoroutine; 

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while(true)
        {
            hitPoints = hitPoints - damage;

            if(hitPoints <= float.Epsilon)
            
            KillerCharacter(); 

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
        if(other.gameObject.tag == "player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
        
            if(damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength,1.0f));
            }
        }

        
        
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.tag == "player")
        {
            if(damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
        
    }
}
