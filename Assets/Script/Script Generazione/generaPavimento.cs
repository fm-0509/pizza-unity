using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generaPavimento : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject FloorTile;
     public GameObject FloorTile1;
     public GameObject Terra;

    public int BordoOrizzontale=0, Altezza=0, Larghezza=0, BordoVerticale=0;

    void Start()
    {
        GameObject Tile;
        for(int i=0; i<Altezza; i++)
            for(int j=0; j<Larghezza; j++){
                if((i+j)%2==0)
                Tile = Instantiate(FloorTile, new Vector3(j,0,i), Quaternion.identity);
                else
                Tile = Instantiate(FloorTile1, new Vector3(j,0,i), Quaternion.identity);
                Tile.transform.parent=gameObject.transform;
            }   
        //Muri laterali
        for(int i=0; i<Altezza; i++){
            for(int j=0; j<BordoOrizzontale; j++){
                Tile = Instantiate(Terra, new Vector3(j,1,i), Quaternion.identity);
                Tile.transform.parent=gameObject.transform;
            }
            for(int j=Larghezza-BordoOrizzontale; j<Larghezza; j++){
                Tile = Instantiate(Terra, new Vector3(j,1,i), Quaternion.identity);
                Tile.transform.parent=gameObject.transform;
            }  
        }
        //Muri superiori
            for(int j=BordoOrizzontale; j<Larghezza-BordoOrizzontale; j++){
            for(int i=0; i<BordoVerticale; i++){
                Tile = Instantiate(Terra, new Vector3(j,1,i), Quaternion.identity);
                Tile.transform.parent=gameObject.transform;
            }
            for(int i=Altezza-BordoVerticale; i<Altezza; i++){
                Tile = Instantiate(Terra, new Vector3(j,1,i), Quaternion.identity);
                Tile.transform.parent=gameObject.transform;
            }  
        }
    }

}
