using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Partita : MonoBehaviour
{
    public static int livello=0;
    public GameObject[] ArrayOstacoli;

    public GameObject[] nemiciSpawnabili;

    private static List<GameObject> nemiciSpawnati=new List<GameObject>();
    public GameObject asset;

    public GameObject playerO;


    // Start is called before the first frame update
    void Start()
    {
        nemiciSpawnati.Add(Instantiate(nemiciSpawnabili[0], new Vector3(2,1,3), new Quaternion(0,0,0,0)));
        nemiciSpawnati.Add(Instantiate(nemiciSpawnabili[1], new Vector3(6,1,10), new Quaternion(0,0,0,0)));
        nemiciSpawnati.Add(Instantiate(nemiciSpawnabili[0], new Vector3(5,1,-5), new Quaternion(0,0,0,0)));
    }

    void FixedUpdate(){
        if(nemiciSpawnati.Count==0)
            OnCollisionEnter(null);
    }

    void OnCollisionEnter(Collision collision){
        livello = livello + 1;
        Vector3 vettore = new Vector3(0,0,30*livello);
        Quaternion q = new Quaternion(0,0,0,0);
        generaPavimentoNew.generaLivello(vettore, q, asset);
        Genera();
       // GeneraOstacoli.generaOstacoli(ArrayOstacoli, Random.Range(0, 255), vettore, q);
    }

    public static List<GameObject> getListaNemici(){
        return nemiciSpawnati;
    }

    public void Genera(){
        Debug.Log("hello");
        nemiciSpawnati.Add(Instantiate(nemiciSpawnabili[0], new Vector3(2,1,3+30*livello), new Quaternion(0,0,0,0)));
        nemiciSpawnati.Add(Instantiate(nemiciSpawnabili[1], new Vector3(6,1,10+30*livello), new Quaternion(0,0,0,0)));
        nemiciSpawnati.Add(Instantiate(nemiciSpawnabili[0], new Vector3(5,1,-5+30*livello), new Quaternion(0,0,0,0)));
    }

    public static GameObject getTarget(){
        Dictionary<Nemico, GameObject> l = new Dictionary<Nemico, GameObject>();
        foreach(GameObject o in nemiciSpawnati){
            if(o !=null && converti(o)!=null)
            l.Add(converti(o),o);
        }
        List<Nemico> nemici = new List<Nemico>(l.Keys);

        foreach(Nemico n in nemici){
            if(n.isVicino)
                return l[n];
        }
        return null;
    }

    public static Nemico converti(GameObject c){
        if(c!=null){
        if(c.GetComponentInChildren<Poliziotto>()!=null)
           return (Nemico) c.GetComponentInChildren<Poliziotto>();
        else if(c.GetComponentInChildren<Donna>()!=null)
           return (Nemico) c.GetComponentInChildren<Donna>();
        else if(c.GetComponentInChildren<Nemico2>()!=null)
           return (Nemico) c.GetComponentInChildren<Nemico2>();
        else if(c.GetComponentInChildren<Zombie>()!=null)
            return (Nemico) c.GetComponentInChildren<Poliziotto>();
        }
            return null;
    }

    public static Player convertiP(GameObject c){
        if(c!=null){
        if(c.GetComponentInChildren<Player>()!=null)
           return (Player) c.GetComponentInChildren<Player>();
        else if(c.GetComponent<Player>()!=null)
            return (Player) c.GetComponent<Player>();
        }
        return null;
    }

    public static void distruggi(GameObject c){
        Debug.Log(c);
        Debug.Log(c.gameObject);
        Debug.Log(c.gameObject.gameObject);
        Destroy(c);
        getListaNemici().Remove(c.gameObject);
        Debug.Log(getListaNemici().Count);
        Destroy(c.gameObject.GetComponentInParent<Transform>().gameObject);
    }
}




