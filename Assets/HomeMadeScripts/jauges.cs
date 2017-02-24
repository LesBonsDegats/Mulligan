using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jauges : MonoBehaviour {

    public int init_max;
    public int life;
    public float init_coef_taille;

    public Text IntIndicator;
    // Use this for initialization
    void Start ()
    {
        life = init_max;
        init_coef_taille = this.transform.localScale.z / init_max;
      

    }
	//j'ai dégagé le update qui n'était pas nécessaire
    public void change(int delta)
    {
        life += delta;
        if (life< 0)
        {
            life = 0;
        }
        else if (life > init_max)
        {
            life = init_max;
        }
        else
        {
            float delta_taille = init_coef_taille * delta;
            this.transform.localScale += new Vector3(0, 0, delta_taille);
            this.transform.localPosition += new Vector3(-delta_taille / 2, 0, 0);
        }


    }

    private void OnMouseEnter()
    {
        IntIndicator.text = life.ToString() + " / " + init_max.ToString();
    }

    private void OnMouseExit()
    {
        IntIndicator.text = "";
    }
}
