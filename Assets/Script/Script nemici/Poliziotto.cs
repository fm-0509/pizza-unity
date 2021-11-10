using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poliziotto : MonoBehaviour
{
    public float timeBetweenShoots;
    public GameObject proiettile;
    GameObject target;
    float waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        waitingTime=timeBetweenShoots;
        GetComponent<Animator>().SetBool("isShooting", false);
        target=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 differenza=target.transform.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0, angolo, 0);
        if(waitingTime<=0){
            Instantiate(proiettile, transform.position+differenza.normalized, Quaternion.Euler(90, angolo,0));
            waitingTime=timeBetweenShoots;
            GetComponent<Animator>().SetBool("isShooting", true);
        }
        else{
            waitingTime-=Time.deltaTime;
            GetComponent<Animator>().SetBool("isShooting", false);
        }
    }
}
