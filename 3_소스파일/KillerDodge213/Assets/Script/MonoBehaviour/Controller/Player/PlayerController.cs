using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController :  Character
{
    HitPoints hitPoints;
    
   
    public float LevelPoints; // 시간 안될꺼 같으면 빼자 
    
    public HealthBar healthBar;
    GameManager gamemanger;


  


    // Start is called before the first frame update
    void Start()
    {
        hitPoints = healthBar.hitPoints;

        hitPoints.value = startingHitPoints;

        

        healthBar.character = this;
        
        //hp 관련 코드
     

    }

    // Update is called once per frame
   

    

        void OnTriggerEnter(Collider other) 
        {
            Debug.Log("아야야ㅑ");
            if(other.tag == "Item") //comparetag를 이용하면 접촉판단이 안된다.
            {
                ItemData hitObject = other.gameObject.GetComponent<Consumable>().Item;
                if(hitObject != null)// 아이템을 건드리면
                {
                    bool shouldDisappear = false;
                    Debug.Log("아이템과 접촉하였습니다."+ hitObject.name);
                    switch(hitObject.itemType)
                    {
                        case ItemData.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        
                        break;
                    
                        case ItemData.ItemType.Points:
                        gamemanger.AddScore(3);
                        //스킬 포인트를 모아서 레벨업 하는 형식으로 만들 얘정
                        //점수 올리는것으로 대체 
                        break;

                        default :
                        break;


                    }
                    if(shouldDisappear)
                    {
                    other.gameObject.SetActive(false);
                    //원래 other 이라고 써있었음 게임 오브젝트 먹으면 사라짐
                    }
                }

            }   
        
        }

    
        public bool AdjustHitPoints(int amount)
        {
            if(hitPoints.value < maxHitPoints)
            
            {
            hitPoints.value = hitPoints.value  + amount;
            Debug.Log("Adjusted hitPoints by :" + amount + "New value" + hitPoints); // 디버그 로그로 바꿔 그냥
            return true;
            }
            return false;

           
            
        }


    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while(true)
        {
            hitPoints.value = hitPoints.value  - damage;
            if(hitPoints.value < float.Epsilon)
            {
                healthBar.HPBar.fillAmount = 0;
                KillerCharacter();
                Die();
                break;
            }

            if(interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void KillerCharacter()
    {
        base.KillerCharacter();

        Destroy(healthBar.gameObject);
    }

   
}

