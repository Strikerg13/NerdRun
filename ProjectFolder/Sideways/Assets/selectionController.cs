using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class selectionController : MonoBehaviour {

    Button btn;
    EventSystem es;


    void Awake()
    {
        if (startMenuController.gameIsPaused)
        {
            btn = GameObject.Find("btnResume").GetComponent<Button>();
            es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            es.SetSelectedGameObject(btn.gameObject);
        }

    }

}
