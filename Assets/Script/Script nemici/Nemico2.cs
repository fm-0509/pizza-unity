using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Nemico2 : Nemico
{

    public float range=3.0f;

    // Start is called before the first frame update
        protected override void Init()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        float distanza= Vector3.Distance(target.transform.position, transform.position);
        if(distanza<=range)
            agent.SetDestination(target.transform.position);
    }

    public override void attack(){
        //todo
    }
}
