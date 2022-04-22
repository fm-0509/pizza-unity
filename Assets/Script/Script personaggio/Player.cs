using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, Danneggiabile
{
    public int danno{get; set;}
    public int vita{get; set;}
    public float speed;
    public DynamicJoystick variableJoystick;
    public GameObject rb;

    public GameObject proiettile;
    public bool isMoving;

    public float waitingTime;

    public float timeBetweenShoots;

    private GameObject vicino;
    public GameObject haiPerso;

    public GameObject generatore;




    public void Start(){
        isMoving=true;
        GetComponentInChildren<Animator>().SetBool("isMooving", true);
        GetComponentInChildren<Animator>().SetBool("gameOver", false);
        vita=100;
        danno = 25;
        GameObject vicino = calcolaVicino().Key;
    }
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
 
        if(direction != Vector3.zero){
            if(vicino!=null)
            Partita.converti(vicino).isVicino=false;
            isMoving=true;
            GetComponentInChildren<Animator>().SetBool("isMooving", true);
            rb.transform.Translate(new Vector3(0,0,1)*speed);
            float angolo= Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical)*Mathf.Rad2Deg;
            transform.rotation= Quaternion.Euler(0, angolo, 0);
        }
        if(direction == Vector3.zero){
            vicino = calcolaVicino().Key;
            isMoving=false;
            GetComponentInChildren<Animator>().SetBool("isMooving", false);
            if(vicino!=null)
            attack(vicino);
        }
        
    }

    public void attack(){
        vicino = calcolaVicino().Key;
        if(vicino!=null)    
            attack(vicino);
    }

    void attack(GameObject target){
        Vector3 differenza=target.transform.position-transform.position;
        float angolo= Mathf.Atan2(differenza.x, differenza.z)*Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0, angolo, 0);
        if(waitingTime<=0){
            Instantiate(proiettile, transform.position+differenza.normalized+new Vector3(0,1,0), Quaternion.Euler(90, angolo,0));
            waitingTime=timeBetweenShoots;
        }
        else{
            waitingTime-=Time.deltaTime;
        }
    }
    KeyValuePair<GameObject,float> calcolaVicino(){
        Nemico nm;
        Dictionary<GameObject,float> nemico2distanza=riempiMappa();
        if(nemico2distanza.Count>0){
        KeyValuePair<GameObject,float> risultato = nemico2distanza.First();

        foreach(KeyValuePair<GameObject,float> f in nemico2distanza){
            if(f.Value<risultato.Value)
                risultato=f;
        }
        if(risultato.Key!=null){
            nm=Partita.converti(risultato.Key);
            if(nm!=null)
                nm.isVicino=true;
        }
        return risultato;
        }
        return new KeyValuePair<GameObject, float>(null,0);
    }
    Dictionary<GameObject, float> riempiMappa(){
        Dictionary<GameObject, float> nemico2distanza = new Dictionary<GameObject, float>();
        if(Partita.getListaNemici() != null){
        List<GameObject> l = Partita.getListaNemici();
        float distanza;
        foreach(GameObject n in l){
            if(n!=null){
            distanza = Mathf.Sqrt(
                Mathf.Pow(n.transform.position.x-transform.position.x,2)+
                Mathf.Pow(n.transform.position.y-transform.position.y,2)+
                Mathf.Pow(n.transform.position.z-transform.position.z,2));
            nemico2distanza.Add(n, distanza);
            }
        }
    }
        return nemico2distanza;
    }
     public static void finisci(GameObject g, GameObject h){
                SceneManager.LoadSceneAsync(0);
    }

    public void prendiDanno(int damage){
        if((this.vita-damage)>0)
            this.vita-=damage;
        else{
            GetComponentInChildren<Animator>().SetBool("gameOver", true);
            finisci(generatore, haiPerso);
        }
    }
}