using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BulletController : MonoBehaviour
{
    public float speed = 8.0f;
    private Rigidbody PB_rigid;
    private Transform PB_trans;

    public GameObject Enemy;
    GameObject wall;
    GameObject wall1;

    // Start is called before the first frame update
    void Start()
    {
        PB_trans = GetComponent<Transform>();
        PB_rigid = GetComponent<Rigidbody>();
        PB_rigid.velocity = transform.forward * speed;
        this.Enemy = GameObject.Find("Enemy");
       
        Destroy(gameObject,3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *Time.deltaTime);
        //총알 날아가게 만들기
        //transform을 이용하여 1프레임마다 앞으로 가도록 설정하였습니다. 공간은 3차원을 이용하여서 vector3를 이용하였습니다.

    }
  
  /// <summary>
  /// Collider 를 이용하여 다른 물체와 접촉하면 트리거가 작동하도록 매서드를 작성하였습니다
  /// Tag시스템을 이용하여 적 오브젝트 하나하나 지정하는것이 아닌 한 분류로 묶어서 프리팹을 이용하여 생성한 적들을 제거하도록 구현했습니다.
  /// </summary>

    void OnTriggerEnter(Collider other)
  {
        BulletSpawner bulletSpawner;
       

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
        ///<summary>
        /// 플레이어가 사용하는 총알의 스크립트이기 때문에  적을 만나면 적 오브젝트를 삭제하는 방식으로 구현하였습니다.
        /// </summary>
        
  }




}
