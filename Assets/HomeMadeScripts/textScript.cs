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
    public GameObject fiche;

    public Button FrcPlus;
    public Button AgiPlus;
    public Button IntPlus;
    public Button ChaPlus;
    public Button LckPlus;

    public Button FrcMoins;
    public Button AgiMoins;
    public Button IntMoins;
    public Button ChaMoins;
    public Button LckMoins;

    public Button ConfirmButton;
    public Text ConfirmText;

    private List<Button> PlusMoinsButtons = new List<Button>();
    private int PotentialFrc = 0;
    private int PotentialAgi = 0;
    private int PotentialInt = 0;
    private int PotentialCha = 0;
    private int PotentialLck = 0;

    public int specPoints = 0;

    void Start () {
        change_text();
        gameObject.SetActive(false);
        nom.text = s.Name + ", niveau 1";

        PlusMoinsButtons = new List<Button>
    {
        FrcPlus,
        AgiPlus,
        IntPlus,
        ChaPlus,
        LckPlus,
        FrcMoins,
        AgiMoins,
        IntMoins,
        ChaMoins,
        LckMoins,
        ConfirmButton
    };

    }
    public void change_text()
    {
        vie.text = "Vie : " + s.life.ToString() + "/" + s.lifemax.ToString(); ;
        nourriture.text = "Nourriture :" + s.hunger.ToString() +"/" + s.hungermax.ToString(); ;
        or.text = "Or : " + s.gold.ToString();
        moral.text = "Moral: " + s.moral.ToString() + "/" + s.moralmax.ToString();
        experience.text = "Experience:  " + s.xp.ToString() + "/" + s.xpmax.ToString();
        Force.text = "Force:  " + (s.strenght + PotentialFrc).ToString();
        Chance.text = "Chance:  " + (s.luck +PotentialLck).ToString();
        Charisme.text = "Charisme:  " + (s.charisma +PotentialCha).ToString();
        Agilité.text = "Agilité:  " + (s.agility + PotentialAgi).ToString();
        Intelligence.text = "Intelligence:  " + (s.intel + PotentialInt).ToString();
    }

    public void addPotentialPoint(int attributeId)
    {
        PotentialFrc += attributeId / 10000;
        PotentialAgi += attributeId % 10000 / 1000;
        PotentialInt += attributeId % 1000 / 100;
        PotentialCha += attributeId % 100 / 10;
        PotentialLck += attributeId % 10;
        specPoints--;
        change_text();
        ButtonUpdate();
    }

    public void removePotentialPoint(int attributeId)
    {
        PotentialFrc -= attributeId / 10000;
        PotentialAgi -= attributeId % 10000 / 1000;
        PotentialInt -= attributeId % 1000 / 100;
        PotentialCha -= attributeId % 100 / 10;
        PotentialLck -= attributeId % 10;

        specPoints++;
        change_text();
        ButtonUpdate();

        
    }


    public void LevelUp()
    {
        nom.text = "Vous atteignez le niveau "+s.level.ToString()+" !";
        s.canMove = false;
        specPoints++;

        foreach (Button b in PlusMoinsButtons)
        {
            b.gameObject.SetActive(true);
        }
        ButtonUpdate();
        change_text();
    }


    public void Confirm()
    {
        s.strenght += PotentialFrc;
        s.agility += PotentialAgi;
        s.intel += PotentialInt;
        s.charisma += PotentialCha;
        s.luck += PotentialLck;

        PotentialFrc = 0;
        PotentialAgi = 0;
        PotentialInt = 0;
        PotentialCha = 0;
        PotentialLck = 0;

        foreach (Button b in PlusMoinsButtons)
        {
            b.gameObject.SetActive(false);
        }
        nom.text = s.Name + ", niveau " + s.level;
        s.canMove = true;
    }

    public void ButtonUpdate()
    {
        for (int i = 0; i < 5; i++)
        {
            PlusMoinsButtons[i].enabled = (specPoints > 0);
        }
        FrcMoins.enabled = PotentialFrc > 0;
        AgiMoins.enabled = PotentialAgi > 0;
        IntMoins.enabled = PotentialInt > 0;
        ChaMoins.enabled = PotentialCha > 0;
        LckMoins.enabled = PotentialLck > 0;

        ConfirmText.enabled = specPoints == 0;
        ConfirmText.text = specPoints > 0 ? specPoints.ToString() : "Confirmer";
    }




    // Update is called once per frame
    


	// Update is called once per frame
	void Update () {
	}
}
