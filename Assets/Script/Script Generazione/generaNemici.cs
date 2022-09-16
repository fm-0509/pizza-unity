using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;


public class GeneraNemici : MonoBehaviour
{
    static protected List<Vector3> posizioni=new List<Vector3>{ new Vector3(-5,1,-2), new Vector3(-5,1,3), new Vector3(-5,1,8),
                                                                new Vector3(0,1,-2),new Vector3(0,1,3),new Vector3(0,1,8),
                                                                new Vector3(5,1,-2),new Vector3(5,1,3),new Vector3(5,1,8),};
        public static void generaNemici(GameObject[] nemiciSpawnabili, int livello){
            int numeroNemici = ((int)livello/5)+3;
            if(numeroNemici>9)
                numeroNemici=9;
            System.Random rnd = new System.Random();
            Vector3[] randomized = posizioni.OrderBy(item => rnd.Next()).ToArray();
            for(int i=0; i<numeroNemici; i++){
            Partita.getListaNemici().Add(Instantiate(nemiciSpawnabili[(int)Random.Range(0, nemiciSpawnabili.Length)], randomized[i]+new Vector3(0,0,25*livello), new Quaternion(0,0,0,0)));
        }
    }

}
