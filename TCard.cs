using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCard : MonoBehaviour {

    public GameObject floor;
    public GameObject player;
    public GameObject THIS;
    public GameObject camera;

    public GameObject TCard1;
    public GameObject TCard2;

    private GameObject NewCard;

    public int x = 0;
    public int z = 0;

    public System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {

        x = (int)THIS.transform.position.x;
        z = (int)THIS.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {

        if (player.transform.position.x == x 
            && player.transform.position.z == z)
        {
            int tirage = rnd.Next(1, 3);

            switch (tirage)
            {
                case 1:
                    NewCard = TCard1;
                    break;
                case 2:
                    NewCard = TCard2;
                    break;

            }
            Instantiate(NewCard, new Vector3(x, 1, z), Quaternion.identity, floor.transform);
            THIS.SetActive(false);
        }
		
	}
}
