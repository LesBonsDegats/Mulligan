using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIControler : MonoBehaviour {
    Text statustext;
	// Use this for initialization
	void Start () {
        statustext = GameObject.Find("statustext").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        statustext.text = "Status: " + PhotonNetwork.connectionStateDetailed.ToString();

    }
}
