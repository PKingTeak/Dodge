using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody p_rigid;
   

    public float speed = 8.0f;
    public GameObject Gun;

    private Quaternion localRotation ;

    private int Key = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        p_rigid = GetComponent<Rigidbody>();
        this.Gun = GameObject.Find("Gun");

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity =  new Vector3(xSpeed,0.0f,zSpeed);

        p_rigid.velocity = newVelocity;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            Key = 1;
          
           transform.Rotate(0.0f, Key, 0.0f);
           
        }
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Key = -1;
          
            transform.Rotate(0.0f, Key, 0.0f);
          
        }
        


         //transform.localScal = new Vector3(xInput,0.0f,0.0f);
// 회전 중심축으로 캐릭터 회전시키는거 일단 질문 매서드 적용이 안됨.
        
    }



         public void Die() 
    {
        gameObject.SetActive(false); 
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();

    }

}
