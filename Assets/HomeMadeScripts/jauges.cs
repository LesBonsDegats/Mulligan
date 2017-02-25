using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jauges : MonoBehaviour {

    public int init_max;
    public int attribute;
    public float init_coef_taille;
    public GameObject cam;
    public NewBehaviourScript s;
    public string type;

    public Text IntIndicator;
    // Use this for initialization
    void Start ()
    {
      init_coef_taille = this.transform.localScale.z / init_max;
        s = cam.GetComponent<NewBehaviourScript>();

        attribute = init_max;

    }
	//j'ai dégagé le update qui n'était pas nécessaire
    public void change(int delta)
    {
        
        
        attribute += delta;
        if (attribute< 0)
        {
            attribute = 0;
        }
        else if (attribute > init_max)
        {
            attribute = init_max;
        }
        else
        {
            float delta_taille = init_coef_taille * delta;
            this.transform.localScale += new Vector3(0, 0, delta_taille);
            this.transform.localPosition += new Vector3(-delta_taille / 2, 0, 0);
        }

        switch (type)
        {
            case "life":
                s.life = attribute;
                s.lifemax = init_max;
                break;

            case "hunger":
                s.hunger = attribute;
                s.lifemax = init_max;
                break;

            case "moral":
                s.moral = attribute;
                s.moralmax = attribute;
                break;
        }



    }

    private void OnMouseEnter()
    {
        IntIndicator.text = attribute.ToString() + " / " + init_max.ToString();
    }

    private void OnMouseExit()
    {
        IntIndicator.text = "";
    }
}
