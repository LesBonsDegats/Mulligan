using UnityEngine;
using System.Collections;

public class jauges : MonoBehaviour {

    public int init_max;
    public int life;
    public float init_coef_taille;
    // Use this for initialization
    void Start ()
    {
        life = init_max;
        init_coef_taille = this.transform.localScale.x / init_max;

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
        float delta_taille = init_coef_taille * delta;
        this.transform.localScale += new Vector3(delta_taille, 0, 0);
        this.transform.localPosition += new Vector3(delta_taille/2, 0, 0);
    }
}
