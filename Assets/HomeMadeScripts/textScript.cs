using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textScript : MonoBehaviour {
    NewBehaviourScript s;
    Text vie;
    Text nourriture;
    Text or;
    Text experience;
    Text moral;
    Text force;
    Text Agilité;
    Text Force;
    Text Chance;
    Text Charisme;
    Text Intelligence;
    Text nom;
    // Use this for initialization
    void Start () {
        change_text();
	}
	public void change_text()
    {
        vie.text = "vie:" + s.life.ToString();
        nourriture.text = "nourriture:" + s.hunger.ToString();
        or.text = "or:" + s.gold.ToString();
    } 
	// Update is called once per frame
	void Update () {
		
	}
}
