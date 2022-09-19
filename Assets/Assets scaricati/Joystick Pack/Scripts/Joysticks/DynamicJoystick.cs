using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;
    Vector3 posRelativa;
    Canvas bordo;

    protected override void Start()
    {
        bordo = this.GetComponentInParent<Canvas>();
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(true);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        //background.gameObject.SetActive(true);
        //posIniziale=new Vector3(background.gameObject.transform.position.x,background.gameObject.transform.position.y, background.gameObject.transform.position.z);
        posRelativa = bordo.transform.localPosition;
        var cameraObj =GameObject.FindWithTag("MainCamera");
        var camera = cameraObj.GetComponent(typeof(Camera)) as Camera;
      //  Vector3 appoggio = camera.ScreenToWorldPoint((new Vector3(Screen.width/2.0f,0,Screen.height/7.5f)));
         Vector3 appoggio = camera.ScreenToWorldPoint((new Vector3(-3240,0,256)));
        posRelativa-=appoggio;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        // background.gameObject.SetActive(false);
         //background.gameObject.SetActive(true);
       // Vector3 posFinale = new Vector3(background.gameObject.transform.position.x,background.gameObject.transform.position.y, background.gameObject.transform.position.z);
        Vector3 posizione = transform.TransformPoint(posRelativa);
      //  var cameraObj =GameObject.FindWithTag("MainCamera");
        //var camera = cameraObj.GetComponent(typeof(Camera)) as Camera;
        //Vector3 appoggio = camera.ScreenToWorldPoint((new Vector3(Screen.width/2.0f,0,Screen.height/7.5f)));
        //posizione+=appoggio;
        background.gameObject.transform.position=posizione;



        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}