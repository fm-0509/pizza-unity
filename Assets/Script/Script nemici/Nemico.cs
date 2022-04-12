using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Nemico : MonoBehaviour, Danneggiabile
{

    public int vita{get; set;}

    public int danno{get; set;}
    
    protected NavMeshAgent agent;
    protected GameObject target;

    public bool isMoving;

    public bool isAttacking;

    public bool isVicino;

    void Start(){
        target=GameObject.FindGameObjectWithTag("Player");
        agent=GetComponent<NavMeshAgent>();
        isMoving=false;
        isAttacking=false;
        isVicino=false;
        Init();
        vita=100;
        danno=5;
    }

    public void prendiDanno(int damage){
        if((this.vita-damage)>0)
        this.vita-=damage;
        else
        Partita.distruggi(gameObject);
    }

    protected abstract void Init();
    abstract public void attack();

    
}
