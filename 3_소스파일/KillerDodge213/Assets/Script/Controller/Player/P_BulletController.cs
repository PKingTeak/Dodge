using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BulletController : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody PB_rigid;
    private Transform PB_trans;

    public GameObject Enemy;
  
    // Start is called before the first frame update
    void Start()
    {
        PB_trans = GetComponent<Transform>();
        PB_rigid = GetComponent<Rigidbody>();
        PB_rigid.velocity = transform.forward * speed;
     

        Destroy(gameObject,3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.3f * Time.deltaTime);
        //총알 날아가게 만들기
    }
private void OnTriggerEnter(Collider other) 
{
    BulletSpawner bulletSpawner;
        Debug.Log("적 파괴");
        
        if(other.tag == "Wall")  // 벽에 충돌했을때 사라지는거고 
        {
            Destroy(gameObject,0.0f);
        }

        if(other.tag == "Enermy")
        {
            bulletSpawner = other.GetComponent<BulletSpawner>();

            if(bulletSpawner != null)
           { 
            bulletSpawner.E_Die();
            Debug.Log("spawner die");
           }
        }
        // 적 오브젝트 파괴
    
} 





}
