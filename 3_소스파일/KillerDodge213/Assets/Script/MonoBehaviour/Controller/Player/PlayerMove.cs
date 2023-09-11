using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   Rigidbody rigid;

    public float speed = 6;

 
    int Key = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        
        Vector3 newVelocity =  new Vector3(xSpeed,0,zSpeed);
       // monobehavior가 참조 안되서 안되는거 같음
        rigid.velocity = newVelocity;
        

        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Key = 1;
            transform.Rotate(0.0f, Key,0.0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Key = -1;
           
            transform.Rotate(0.0f, Key, 0.0f);
           
        }

       
    }
}
