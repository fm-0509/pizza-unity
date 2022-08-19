using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GeneraNemici : MonoBehaviour
{
        public static void generaNemici(GameObject[] nemiciSpawnabili, int livello){
            int numeroNemici = 5;
        for(int i=0; i<numeroNemici; i++){
        Partita.getListaNemici().Add(Instantiate(nemiciSpawnabili[(int)Random.Range(0, nemiciSpawnabili.Length)], new Vector3(Random.Range(-2, 2),1,5+Random.Range(-2, 2)+25*livello), new Quaternion(0,0,0,0)));
        }


    }

}
