using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody B_rigid; //외부에서 못만지게 하고싶음.

   
    public  int damageStrength;
    Coroutine damageCoroutine; 

   

    

    // Start is called before the first frame update
    void Start()
    {
        B_rigid = GetComponent<Rigidbody>();
        B_rigid.velocity = transform.forward * speed;

        
      

        Destroy(gameObject,5.0f);   // 총알 삭제
    }
    
    private void OnTriggerEnter (Collider other) 
    {
        Debug.Log("아야");
        if(other.gameObject.tag == "Player")
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
        
            if(damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength,1.0f));
            }
        }

        
        
    }
    
    
}




  

