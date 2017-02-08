using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaireSlot : MonoBehaviour {

   // private Sprite s;
    public int id = 0;


    public GameObject MainCam;

    public int type;

    public SpriteRenderer sr;


	// Use this for initialization
	void Start () {
        setId(id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setId(int a)
    {
        id = a;

        Items i = MainCam.GetComponent<Items>();
        Sprite image = i.ImageList[a];

        sr.sprite = image;
    }
}
