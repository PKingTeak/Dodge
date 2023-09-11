using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 6.0f;
    private Rigidbody B_rigid; //외부에서 못만지게 하고싶음.

    public GameManager gameManager;

    
    

    // Start is called before the first frame update
    void Start()
    {
        B_rigid = GetComponent<Rigidbody>();
        B_rigid.velocity = transform.forward * speed;



        Destroy(gameObject,4.0f);  
    }


    void OnTriggerEnter(Collider other) //다른것과 충돌했는지 확인

    {
        PlayerController playerController;
        Debug.Log("Player Collider IN");

        if(other.tag == "Wall")  // 벽에 충돌했을때 사라지는거고 
        {
            Destroy(gameObject,0);
        }
            //tag불러오는 코드
        if(other.tag == "Player") // 플레이어 충돌시 
        {
         playerController = other.GetComponent<PlayerController>();   


        
            if(playerController != null) 
           {
            Debug.Log("Player DIE");
            playerController.Die();
           }
        }
        
    }
}

