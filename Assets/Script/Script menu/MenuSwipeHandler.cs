using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using PlayFab;
//using PlayFab.ClientModels;

public class MenuSwipeHandler : MonoBehaviour
{
    public GameObject scrollbar;
    float[] pos;
    float distance = 1f / (3- 1f);
    private float scroll_pos;

    // Start is called before the first frame update
    void Start()
    {
        scroll_pos = distance;
        //PlayfabManager.Login(onSuccess, error);
    }

    
    // Update is called once per frame
    void Update()
    {
        pos = new float[3];
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }


       /* for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Level" + i);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }/**/

    }


    private void error(PlayFabError obj)
    {
        Debug.Log("PlayFabLoginError " + obj.GenerateErrorReport());
    }

    private void onSuccess(LoginResult obj)
    {
        Debug.Log("Login OK");
    }



}