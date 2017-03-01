using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireSlot : MonoBehaviour {

   // private Sprite s;
    public int id = 0;


    public GameObject MainCam;

    public int type;

    public Image img;

	// Use this for initialization
	void Start () {
        setId(id);
        img = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update() { 
	}

    public void setId(int a)
    {
        id = a;

        Items i = MainCam.GetComponent<Items>();
        Sprite image = i.ImageList[a];

        img.sprite = image;

       // i = image;

        
    }



}
