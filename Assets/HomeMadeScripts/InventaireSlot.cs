using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireSlot : MonoBehaviour {

   // private Sprite s;
    public int id = 0;


    public GameObject MainCam;

    public string type;

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


    public bool hasSameType(string type, int id)
    {
        switch (type)
        {  // changer les valeurs pour changer le nombre d'objets différents possible de chaque catégorie
            case "lHand":
                return id < 10;
            case "helmet":
                return 10 < id && id < 20;
            case "chest":
                return 20 < id && id < 30;
            case "greaves":
                return 30 < id && id < 40;
            case "rHand":
                return 40 < id && id < 50;
            case "t":
                return 50 < id;
        }
        return false;

    }



}
