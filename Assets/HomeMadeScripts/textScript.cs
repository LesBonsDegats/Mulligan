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

    public Text ChooseOne;
    public Button Choice1;
    public Button Choice2;

    private Text Choice1_Text;
    private Text Choice2_Text;

    private string Choice1_ability;
    private string Choice2_ability;

    private Image Choice1_img;
    private Image Choice2_img;
    private int chosen;

    public Button ConfirmButton;
    public Text ConfirmText;

    public Scrollbar AbilityScroll;
    public Text AbilityText;

    public string GlobalAbilities; //toutes les compétences acquises
    public string CurrentAbilities;//ce qu'on en voit (scrollbar)

    private List<Button> PlusMoinsButtons = new List<Button>();
    private int PotentialFrc = 0;
    private int PotentialAgi = 0;
    private int PotentialInt = 0;
    private int PotentialCha = 0;
    private int PotentialLck = 0;

    public int specPoints = 0;

    void Start ()
    {

        GlobalAbilities = "";
        change_text();
        gameObject.SetActive(false);
        nom.text = s.Name + ", niveau 1";

        Choice1_img = Choice1.GetComponent<Image>();
        Choice2_img = Choice2.GetComponent<Image>();

        Choice1_Text = Choice1.GetComponentInChildren<Text>();
        Choice2_Text = Choice2.GetComponentInChildren<Text>();

        PlusMoinsButtons = new List<Button>
      {
        Choice1,
        Choice2,
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

    public string Get6LinesStartFromK(string txt, int k)
    {
        string str = "";
        int L = txt.Length;
        int compteur = 0;


        while(k > 0 && compteur < L)
        {
            if (txt[compteur] == '\n')
                k--;
            compteur++;
        }
        k = 6;
        while (k > 0)
        {
            while (compteur < L && txt[compteur] != '\n')
            {
                str += txt[compteur];
                compteur++;
            }
            compteur++;
            str += '\n';
            k--;
        }
        return str;
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

    public void Choose(int choice)// 1 ou 2
    {
        chosen = choice;
        if (chosen == 1)
        {
            Choice1_img.color = Color.yellow;
            Choice2_img.color = Color.white;
        }
        else if (chosen == 2)
        {
            Choice2_img.color = Color.yellow;
            Choice1_img.color = Color.white;
        }
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
        ChooseOne.gameObject.SetActive(true);
        s.canMove = false;
        specPoints++;

        System.Random rnd = new System.Random();

        int count = s.allAbilities.Count;
        Choice1_ability = s.allAbilities[rnd.Next(count)];
        s.allAbilities.Remove(Choice1_ability);
        count--;

        Choice2_ability = s.allAbilities[rnd.Next(count)];
        s.allAbilities.Remove(Choice2_ability);

        Choice1_Text.text = Choice1_ability;
        Choice2_Text.text = Choice2_ability;


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


        if (chosen == 1)
        {
            s.allAbilities.Add(Choice2_ability);
            GlobalAbilities += Choice1_ability + '\n';
            s.getAbility(Choice1_ability);
        }
        else
        {
            s.allAbilities.Add(Choice1_ability);
            GlobalAbilities += Choice2_ability + '\n';
            s.getAbility(Choice2_ability);
        }
        AbilityTextUpdate();

        PotentialFrc = 0;
        PotentialAgi = 0;
        PotentialInt = 0;
        PotentialCha = 0;
        PotentialLck = 0;

        Choice1_img.color = Color.white;
        Choice2_img.color = Color.white;

        foreach (Button b in PlusMoinsButtons)
        {
            b.gameObject.SetActive(false);
        }
        nom.text = s.Name + ", niveau " + s.level;
        ChooseOne.gameObject.SetActive(false);
        s.canMove = true;
    }

    public void ButtonUpdate()
    {


        for (int i = 2; i < 5; i++)
        {
            PlusMoinsButtons[i].enabled = (specPoints > 0);
        }
        FrcMoins.enabled = PotentialFrc > 0;
        AgiMoins.enabled = PotentialAgi > 0;
        IntMoins.enabled = PotentialInt > 0;
        ChaMoins.enabled = PotentialCha > 0;
        LckMoins.enabled = PotentialLck > 0;

        ConfirmButton.enabled = specPoints == 0;
        ConfirmText.text = specPoints > 0 ? specPoints.ToString() : "Confirmer";
    }


    public void AbilityTextUpdate()
    {
        AbilityText.text = Get6LinesStartFromK(GlobalAbilities, (int)(AbilityScroll.value * 6f));

    }

    // Update is called once per frame
    


	// Update is called once per frame
	void Update () {
	}
}
