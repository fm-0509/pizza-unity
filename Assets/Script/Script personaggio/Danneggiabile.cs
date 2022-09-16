using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Danneggiabile
{
    int vita{get; set;}
    int danno{get; set;}

    void prendiDanno(int damage);
    void attack();    
}
