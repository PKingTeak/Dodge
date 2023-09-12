using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 에셋에 영향을 주는 거기 때문에 바깥에 선언 해야된다.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

//굉장히 많이 이용된다.

public class E_wonder : MonoBehaviour
{
    public float pursuitSpeed;
    public float wanderSpeed;
    public float currentSpeed;


    public float directionChangeInterval;
    public bool followPlayer;
    Coroutine moveCoroutine;

    Rigidbody rigid;
    

    Transform targetTransform = null;

    Vector3 endPosition; //추격 하는 끝범위

    float currentAngle = 15; //회전값


    CapsuleCollider capsuleCollider;


   

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = wanderSpeed;
        
        rigid = GetComponent<Rigidbody>();

        StartCoroutine(WanderRoutine());
        capsuleCollider = GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(rigid.position,endPosition,Color.red); // 기억 잘해서 습관을 들여 놓는게 좋을거 같다.
    }

    public IEnumerator WanderRoutine()
    {
    //목표 발견
    // 목표 추격 진행
    // 다시 감시
        while(true)
        {
            ChooseNewEndpoint();

            
                if(moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                }

                moveCoroutine = StartCoroutine(Move(rigid, currentSpeed));

                yield  return new WaitForSeconds(directionChangeInterval);

        }
    }

    public void ChooseNewEndpoint()
    {
       currentAngle +=  Random.Range(0 , 360); // 빙글빙글
        currentAngle = Mathf.Repeat(currentAngle, 360);
        
        endPosition += Vector3FromAngle(currentAngle);
    }
    
    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        //사주경계
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(inputAngleRadians),0,Mathf.Sin(inputAngleRadians));


    }

    public IEnumerator Move(Rigidbody rigidbodyToMove,float speed)
    {
        float remainDistance = (transform.position - endPosition).sqrMagnitude;
        //sqrMagnitude = 제곱근
        while(remainDistance > float.Epsilon)
        {
            if(targetTransform != null)
            {
                endPosition = targetTransform.position;
                

            }

            if(rigidbodyToMove != null)
            {
            
                Vector3 newPosition = Vector3.MoveTowards(rigidbodyToMove.position,endPosition,speed*Time.deltaTime);
                rigid.MovePosition(newPosition);

                remainDistance = (transform.position - endPosition).sqrMagnitude;

            }
        yield return new WaitForFixedUpdate();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player" && followPlayer)
        {
            currentSpeed = pursuitSpeed;
            targetTransform = other.gameObject.transform;
            if(moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rigid,currentSpeed));

        }


    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
           
            currentSpeed = wanderSpeed;

        }
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        targetTransform = null;
        
    }
        void OnDrawGizmos() 
        {
            if(capsuleCollider != null)
            {
                Gizmos.DrawWireSphere(transform.position,capsuleCollider.radius);
            }
            
        }
        //기즈모 함수 추가를 하여 디버깅을 확인하면 눈으로 바로 구별할수 있도록 도움을 받을수 있다.Mathf.Sin(inputAngleRadians)


}
