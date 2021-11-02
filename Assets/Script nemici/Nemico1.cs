using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nemico1 : MonoBehaviour
{
    public float timeBetweenShoots;
    public GameObject proiettile;
    float waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        waitingTime=timeBetweenShoots;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitingTime<=0){
            Instantiate(proiettile, transform.position+new Vector3(0,1,-1), new Quaternion(0.5f,0,0,0));
            waitingTime=timeBetweenShoots;
        }
        else{
            waitingTime-=Time.deltaTime;
        }
    }
}
