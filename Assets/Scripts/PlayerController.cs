using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Transform dove;
    [SerializeField] Transform shootPoint;
    Vector3 spawner;
    [SerializeField] GameObject pop;
    bool shooting = false;
    [SerializeField] float shootDelay = 0.2f;
    Rigidbody doveRigi;
    bool left;
    bool press;
    int contadorPop = 0;
    float timer;
    [SerializeField] float wait;

    void Awake()
    {
        doveRigi = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if (left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (!left)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        spawner = shootPoint.position;
        if(Input.GetKeyDown(KeyCode.A))
        {
            OnLefth();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnRight();
        }

        if (contadorPop>=10)
        {

            shooting = true;
            timer++;
            if (timer>=200)
            {
                shooting = false;
                timer = 0;
                contadorPop = 0;
                
            }
        }
    }

    public void OnLefth()
    {
        left = true;
    }
    public void OnRight()
    {
        left = false;
    }
    public void OnPopShoot()
    {
        if (!shooting)
        {
            contadorPop++;
            shooting = true;
            GameObject Clon = GameObject.Instantiate(pop, spawner, Quaternion.identity);
            Invoke("RestartShoot", shootDelay);
            
        }

    }
    void RestartShoot()
    {
        shooting = false;
    }

}
