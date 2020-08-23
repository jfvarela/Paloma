using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject person = null;
    [SerializeField] GameObject spawnPoint = null;
    Vector3 spawnPosition;
    [SerializeField] protected float spawnTime=4f;
    float timer;
    bool instance=true;



    // Start is called before the first frame update
    void Awake()
    {
        if (spawnPoint!=null)
        {
            spawnPosition = spawnPoint.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        
        if (timer >= spawnTime*100)
        {
            timer = 0;
            instance = false;
        }

        if(person!= null && instance==false)
        {
            //Invoke("ResetSpawnTime", 0f);
            ResetSpawnTime();
        }
    }
    void ResetSpawnTime()
    {
        GameObject Clon = GameObject.Instantiate(person, spawnPosition, Quaternion.identity);
        timer = 0;
        instance = true;

    }
}
