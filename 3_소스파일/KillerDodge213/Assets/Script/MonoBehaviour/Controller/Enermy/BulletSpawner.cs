using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Character
{
    // Start is called before the first frame update
        public GameObject E_bulletPrefab; 
        public float spawnRateMin = 0.5f;
        public float spawnRateMax = 3.0f;
        
        private Transform target;
        private float spawnRate;
        private float timeAfterSpawn; // 발사후 대기 시간
        public float hitPoints;
        public  int damageStrength;
        Coroutine damageCoroutine; 


        GameObject P_Bullet;
    void Start()
    {
        timeAfterSpawn = 0.0f;
        spawnRate = Random.Range(spawnRateMin,spawnRateMax); 
        target = FindObjectOfType<PlayerController>().transform;
        P_Bullet = GameObject.Find("P_Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
    
        if(timeAfterSpawn >= spawnRate)
    {
        timeAfterSpawn = 0.0f;
        GameObject bullet;
        bullet = Instantiate(E_bulletPrefab,transform.position,transform.rotation);
        
        bullet.transform.LookAt(target);

        spawnRate = Random.Range(spawnRateMin,spawnRateMax);
    }

     
    

    }
    public override IEnumerator DamageCharacter(int damage, float interval)
        
        {
            while(true)
            {
                hitPoints = hitPoints - damage;
                if(hitPoints <= float.Epsilon)
                {
                    //죽었을때 
                    KillerCharacter();
                    GameManager.Instance.AddScore(2);               
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
  
}
