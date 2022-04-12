using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class generaNemici : MonoBehaviour
{

    public GameObject[] enemy;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject nemico;
        nemico=Instantiate(enemy[0], new Vector3(3, 1.5f, 2) ,Quaternion.identity);
        nemico=Instantiate(enemy[1], new Vector3(6, 1.5f, 2) , new Quaternion(0,1,0,0));
        nemico=Instantiate(enemy[2], new Vector3(-2, 1.5f, 2) , new Quaternion(0,1,0,0));
    }

}
