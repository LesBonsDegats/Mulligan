using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour {


    public GameObject cam1;
    public GameObject cam2;
    private bool onBoard = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            onBoard = !onBoard;
            Cursor.visible = onBoard;

            cam2.SetActive(!cam2.activeInHierarchy);          
        }


	}
}
