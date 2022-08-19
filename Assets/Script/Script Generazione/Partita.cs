using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Partita : MonoBehaviour
{
    public static int livello=0;
    public GameObject[] ArrayOstacoli;

    public GameObject[] nemiciSpawnabili;

    private static List<GameObject> nemiciSpawnati=new List<GameObject>();
    public GameObject[] asset;

    static int livelloCorrente=0;

    private static Dictionary<int, GameObject> livelli= new Dictionary<int, GameObject>();

    public NavMeshSurface navi;


    // Start is called before the first frame update
    void Start()
    {
        nemiciSpawnati.Clear();
        livelli.Clear();
        livello=0;
        livelloCorrente=0;
        livelli.Add(0, Instantiate(asset[0], new Vector3(0,0,0), asset[0].transform.rotation));
        getLivello(livelloCorrente).transform.GetChild(4).GetChild(0).GetComponent<BoxCollider>().enabled=true;
    }


    void FixedUpdate(){
        livelloCorrente=(int)(GameObject.FindGameObjectWithTag("Player").transform.position.z+11.5)/25;
        if(livelloCorrente==livello){
            generaLivelloSuccessivo();
            if(livelloCorrente!=0){
            getLivello(livelloCorrente-1).transform.GetChild(3).GetChild(0).GetComponent<Animator>().SetBool("isOpen", false);
            getLivello(livelloCorrente).transform.GetChild(4).GetChild(0).GetComponent<BoxCollider>().enabled=true;         
            GeneraNemici.generaNemici(nemiciSpawnabili, livelloCorrente);
            // GeneraOstacoli.generaOstacoli(ArrayOstacoli, Random.Range(0, 255), vettore, q);
            }
        }
        if(nemiciSpawnati.Count==0){
            getLivello(livello).transform.GetChild(4).GetChild(0).GetComponent<BoxCollider>().enabled=false;
            getLivello(livelloCorrente).transform.GetChild(3).GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);
        }
    }

    void generaLivelloSuccessivo(){
        int i= UnityEngine.Random.Range(0, asset.Length);
        livello = livello + 1;
        Vector3 vettore = new Vector3(0,0,25*livello);
        livelli.Add(livello, Instantiate(asset[i], vettore, asset[i].transform.rotation));
        navi.BuildNavMesh();
    }


    public static GameObject getLivello(int liv){
        return livelli[liv];
    }
    public static List<GameObject> getListaNemici(){
        return nemiciSpawnati;
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

    public static int getLivelloCorrente(){
        return livelloCorrente;
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
            return (Nemico) c.GetComponentInChildren<Zombie>();
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
        getListaNemici().Remove(c.gameObject);
        Destroy(c);
        Destroy(c.gameObject.GetComponentInParent<Transform>().gameObject);
    } 
       public static GameObject getPlayer(){
        return GameObject.FindGameObjectWithTag("Player");
    }
}






