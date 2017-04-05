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

    private List<Button> PlusMoinsButtons = new List<Button>();
    private int PotentialFrc = 0;
    private int PotentialAgi = 0;
    private int PotentialInt = 0;
    private int PotentialCha = 0;
    private int PotentialLck = 0;

    private int specPoints = 0;

    void Start () {
        change_text();
        gameObject.SetActive(false);

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
        Intelligence.text = "Intelligence:  " + (s.intel + PotentialAgi).ToString();
        nom.text = s.Name;
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
        specPoints++;

        foreach (Button b in PlusMoinsButtons)
        {
            b.gameObject.SetActive(true);
        }
        ButtonUpdate();

        /*
        FrcPlus.onClick.AddListener(() => addPotentialPoint(ref PotentialFrc));
        AgiPlus.onClick.AddListener(() => addPotentialPoint(ref PotentialAgi));
        IntPlus.onClick.AddListener(() => addPotentialPoint(ref PotentialInt));
        ChaPlus.onClick.AddListener(() => addPotentialPoint(ref PotentialCha));
        LckPlus.onClick.AddListener(() => addPotentialPoint(ref PotentialLck));

        FrcMoins.onClick.AddListener(() => addPotentialPoint(ref PotentialFrc));
        AgiMoins.onClick.AddListener(() => addPotentialPoint(ref PotentialAgi));
        IntMoins.onClick.AddListener(() => addPotentialPoint(ref PotentialInt));
        ChaMoins.onClick.AddListener(() => addPotentialPoint(ref PotentialCha));
        LckMoins.onClick.AddListener(() => addPotentialPoint(ref PotentialLck));
        */

      //  ConfirmButton.onClick.AddListener(() => Confirm());
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

        Text ConfirmText = ConfirmButton.GetComponent<Text>();

        ConfirmText.text = specPoints > 0 ? specPoints.ToString() : "Confirmer";
    }




    // Update is called once per frame
    


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.U))
        {
            LevelUp();
        }
	}
}
