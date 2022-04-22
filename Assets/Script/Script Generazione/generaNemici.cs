using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneraNemici : MonoBehaviour
{
        public static void generaNemici(GameObject[] nemiciSpawnabili, int livello){
        Partita.getListaNemici().Add(Instantiate(nemiciSpawnabili[0], new Vector3(2,1,3+25*livello), new Quaternion(0,0,0,0)));
        Partita.getListaNemici().Add(Instantiate(nemiciSpawnabili[1], new Vector3(6,1,1+25*livello), new Quaternion(0,0,0,0)));
        Partita.getListaNemici().Add(Instantiate(nemiciSpawnabili[0], new Vector3(5,1,-5+25*livello), new Quaternion(0,0,0,0)));
    }

}
