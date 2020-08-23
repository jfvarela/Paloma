using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    Transform spawnL;
    Transform spawnR;
    Transform person;
    Vector3 targetL;
    Vector3 targetR;
    [SerializeField] float speed=1f;
    bool left = false;

    // Start is called before the first frame update
    void Awake()
    {

        person = GetComponent<Transform>();
        spawnL = GameObject.FindGameObjectWithTag("SpawnL").GetComponent<Transform>();
        spawnR = GameObject.FindGameObjectWithTag("SpawnR").GetComponent<Transform>();

        if (person.position == spawnL.position)
        {
            left = true;
        }
        else if (person.position == spawnR.position)
        {
            left = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!left)
        {
            targetL = GameObject.FindGameObjectWithTag("TargetL").GetComponent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, targetL, speed * Time.deltaTime);
        }
        else if (left)
        {
            targetR = GameObject.FindGameObjectWithTag("TargetR").GetComponent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, targetR, speed * Time.deltaTime);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("TargetL") || other.CompareTag("TargetR"))
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }

    }
}