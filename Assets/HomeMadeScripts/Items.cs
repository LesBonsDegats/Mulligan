using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public Sprite ShadyEncounter;
    public Sprite Crossroad;
    public Sprite The_Gate;
    //etc..


    public List<Sprite> ImageList = new List<Sprite>();

	// Use this for initialization
	void Start () {
        ImageList = new List<Sprite>
        {
            null,
            ShadyEncounter,
            Crossroad,
            The_Gate
        };

	}
	
	// Update is called once per frame
	void Update () {
	}
}
