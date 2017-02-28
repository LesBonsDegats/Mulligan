using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textScript : MonoBehaviour {
     public NewBehaviourScript s;
    public Text vie;
    public Text nourriture;
    public Text or;
    public Text experience;
    public Text moral;
    public Text Agilité;
    public Text Force;
    public Text Chance;
    public Text Charisme;
    public Text Intelligence;
    public Text nom;
    // Use this for initialization
    void Start () {
        change_text();
	}
	public void change_text()
    {
        vie.text = "Vie : " + s.life.ToString() + "/" + s.lifemax.ToString(); ;
        nourriture.text = "Nourriture :" + s.hunger.ToString() +"/" + s.hungermax.ToString(); ;
        or.text = "Or : " + s.gold.ToString();
        moral.text = "Moral: " + s.moral.ToString() + "/" + s.moralmax.ToString();
        experience.text = "Experience:  " + s.xp.ToString() + "/" + s.xpmax.ToString();
        Force.text = "Force:  " + s.strenght.ToString();
        Chance.text = "Chance:  " + s.luck.ToString();
        Charisme.text = "Charisme:  " + s.charisma.ToString();
        Agilité.text = "Agilité:  " + s.agility.ToString();
        Intelligence.text = "Intelligence:  " + s.intel.ToString();
        nom.text = s.name;
    } 
	// Update is called once per frame
	void Update () {
		
	}
}
