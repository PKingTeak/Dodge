using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody B_rigid; //외부에서 못만지게 하고싶음.

   

    

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

        
            //tag불러오는 코드
        if(other.tag == "Player")
        {
            playerController = other.GetComponent<PlayerController>();   


        
            if(playerController != null) 
            Debug.Log("플레이어 사망");
            playerController.KillerCharacter();
            
        }
        
    }
    ///<summary>
    /// 마찬가지로 적들도 플레이어가 쏜 총에 맞으면 사망해야하기 때문에 OnTriggerEnter매서드를 이용하여 충돌을 감지하였습니다.
    ///</summary>

}

