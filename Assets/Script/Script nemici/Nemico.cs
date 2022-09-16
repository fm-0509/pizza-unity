using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Nemico : MonoBehaviour
{

    public int vita{get; set;}

    public int vitaMax;

    public int danno;
    
    protected NavMeshAgent agent;
    
    protected GameObject target;

    protected Animator animator;

    public bool isMoving;

    public bool isAttacking;

    public bool isVicino;

    protected GameObject barraVita;

    public GameObject assetBarraVita;

    void Start(){
        target=GameObject.FindGameObjectWithTag("Player");
        agent=GetComponent<NavMeshAgent>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        isMoving=false;
        isAttacking=false;
        isVicino=false;
        Init();
        vita=vitaMax;
    }

    void LateUpdate(){
        barraVita.transform.rotation = Quaternion.identity;
        barraVita.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = (float) vita / (float) vitaMax;

    }

    void OnCollisionEnter(Collision hit){
        if(hit.collider.CompareTag("Player")){
            Debug.Log("Player");
            Partita.convertiP(hit.gameObject).prendiDanno(danno);
        }
        if(hit.collider.CompareTag("Wall"))
           //todo
           Debug.Log("muro");
}

    public virtual void prendiDanno(int damage){
        if((this.vita-damage)>0)
        this.vita-=damage;
        else
        Partita.distruggi(gameObject);
    }

    protected abstract void Init();
    abstract public void attack();

    
}
