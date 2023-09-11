using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public GameObject P_Bullet;
   

    public Transform FirePos;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
             // 총알 넣을면 될듯
            Debug.Log("총 쏜다.");
            Instantiate(P_Bullet, FirePos.transform.position , FirePos.transform.rotation);

            // 총알 범위 밖으로 나가면 자동 삭제
            // 범위 측정 하기 하직 못해서 시간으로 생각
           
          
            
           
        }

        
    }
}
