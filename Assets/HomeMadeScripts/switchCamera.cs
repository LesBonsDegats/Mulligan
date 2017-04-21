using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour {


    public GameObject cam1;
    public GameObject cam2;
    public AudioSource audiosource;
    private bool onBoard = true;
    

    private AudioListener cam1Listener;

	// Use this for initialization
	void Start () {
        cam1Listener = cam1.GetComponent<AudioListener>();
	}
	
	// Update is called once per frame

    public void changeCamera()
    {
        onBoard = !onBoard;
        Cursor.visible = onBoard;

        bool cam = !cam2.activeInHierarchy;
        cam2.SetActive(cam);
        audiosource.enabled = !cam;
    }
}
