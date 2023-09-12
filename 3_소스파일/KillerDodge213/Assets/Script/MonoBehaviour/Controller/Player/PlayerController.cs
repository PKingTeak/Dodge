using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController :  Character
{
    public HitPoints hitPoints;
    public HealthBar healthBarPrefab;
    HealthBar healthBar;
    GameManager gamemanger;

    LevelBar levelBar;

    

  


    // Start is called before the first frame update
    void Start()
    {
        hitPoints.value = startingHitPoints;

        healthBar = Instantiate(healthBarPrefab);

        healthBar.character = this;
        
        //hp 관련 코드
     

    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    

        void OnTriggerEnter(Collider other) 
        {
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

                        case ItemData.ItemType.Exp:
                        //LevelUp();
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

            // 무적 아이템을 먹었을때 3초 동안 무적을 유지하려면 코루틴을 사용해야되나요?
            
        }


    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while(true)
        {
            if(hitPoints.value < float.Epsilon)
            {
                KillerCharacter();
                gamemanger.EndGame();
                break;
            }

            if(interval >float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
    /// <summary>
    /// Character클래스를 상속받아 캐릭터가 데미지를 입었을때 체력이 줄어들게 구현하였습니다
    /// 오버라이딩 한이유는 적은 한번에 삭제가 되도록 하였지만 플레이어는 체력이 따로 존재하기 때문에 부모 클래스로 각각 따로따로 제어하기 위해 사용하였습니다.
    /// </summary>

    public override void KillerCharacter()
    {
        base.KillerCharacter();

        Destroy(healthBar.gameObject);
    }

    
   
}
/*
public  void LevelUp()
    {
        

        for(Startlevel = 0 ; Startlevel<Maxlevel;Startlevel+=Droplevel)
        {
            if(Startlevel == Maxlevel)
            {
                Maxlevel += Pluslevel; // 경험치량 커지고
                Startlevel = 0; // 시작 경험치는 0으로 초기화 시켜주고

            }
            
        }
s
        

    }
    */