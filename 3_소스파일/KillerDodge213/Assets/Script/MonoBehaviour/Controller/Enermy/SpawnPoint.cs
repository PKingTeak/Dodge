using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public int repeatInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject",0.0f,repeatInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject spawnObject()
    {
        if(prefabToSpawn != null)
        {
        return Instantiate(prefabToSpawn,transform.position , Quaternion.identity);
        }
    return null;
    }
}
