using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BulletController : PlayerController
{
    public float speed = 8.0f;
    private Rigidbody PB_rigid;
    private Transform PB_trans;

    public int damageStrength;
    Coroutine damgeCoroutine;

    
    
    // Start is called before the first frame update
    void Start()
    {
        PB_trans = GetComponent<Transform>();
        PB_rigid = GetComponent<Rigidbody>();
        PB_rigid.velocity = transform.forward * speed;
        
        Destroy(gameObject,4.0f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *Time.deltaTime);
        //총알 날아가게 만들기
    }
  

  private void OnTriggerEnter(Collider other)
  {
       if(other.gameObject.tag == "Enermy")
       {
        C_Enermy enermy = other.gameObject.GetComponent<C_Enermy>();
        
        
        if(damgeCoroutine == null)
        {
            damgeCoroutine = StartCoroutine(enermy.DamageCharacter(damageStrength,1.0f));
            
        }
       }
       if(other.gameObject.tag == "S_Enermy")
       {
        BulletSpawner S_Enermy = other.gameObject.GetComponent<BulletSpawner>();
        if(damgeCoroutine == null)
        {
            damgeCoroutine = StartCoroutine(S_Enermy.DamageCharacter(damageStrength,1.0f));
        }
       }
      
        // 적 오브젝트 파괴
  }




}
