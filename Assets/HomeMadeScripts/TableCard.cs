using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCard : MonoBehaviour
{

    public Sprite Image;       //CHANGE NAME


    //STAPLE


    public GameObject ShowCard;
    public GameObject cam;
    public SpriteRenderer sr;
    public GameObject Player;
    public string cardName;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    public Text B1text;
    public Text B2text;
    public Text B3text;
    public Text B4text;

    private bool a = false;
    private bool b = false;
    private bool c = false;
    private bool d = false;
    public string path = "";
    private float relation = 0f;

    public GameObject Parchemin;
    public Text Recit;
    public Text Titre;

    public bool isDone = false;
    private bool cardPlaying;
    public NewBehaviourScript s;
    private bool stch = false;
    public bool clicked = false;

    private NewBehaviourScript mainscript;
    // Use this for initialization
    void Start()
    {

        Button1.onClick.AddListener(PressButton1);
        Button2.onClick.AddListener(PressButton2);
        Button3.onClick.AddListener(PressButton3);
        Button4.onClick.AddListener(PressButton4);

        s = cam.GetComponent<NewBehaviourScript>();
        SpriteRenderer sr = ShowCard.GetComponent<SpriteRenderer>();
        mainscript = cam.GetComponent<NewBehaviourScript>();

    }


    private void playCard()
    {
        cardPlaying = true;
        clicked = false;
        a = false;
        b = false;
        c = false;
        d = false;
        relation = 0;

        switch (cardName)
        {

            case "TheGate":
                path = "TheGate ";
                Titre.text = "The Gate";
                break;

            case "Gobelins!":
                path = "Gobelins! ";
                Titre.text = "Gobelins!";
                break;

            

        }

        nextDialogue(path);
    }


    IEnumerator WaitForClick()
    {
        while (true)
        {
            
            if (clicked)
            {
                Dial();
                nextDialogue(path);
                clicked = false;
                StopCoroutine("WaitForClick");
            }
 
            yield return new WaitForEndOfFrame();
        }
    }


    public string paragraph(string str)
    {
        int L = str.Length;
        int index = 0;
        int pas = 0;
        string paragraph = "";


        while (L - index > 67)
        {
            pas = 67;

            while (str[pas + index] != ' ')
            {
                pas--;
            }
            paragraph += str.Substring(index, pas) + '\n';
            index += pas;
            
/*
                while(str[index] != ' ')
                {
                    paragraph += str[index];
                    index++;
                }
                */

        }
    
        paragraph += str.Substring(index, L - index);
        return paragraph;
    }

    public void nextDialogue(string pathto)
    {

        System.Random rnd = new System.Random();
        int tirage = 0;

        a = false;
        b = false;
        c = false;
        d = false;

        Button1.enabled = true;
        Button2.enabled = true;
        Button3.enabled = true;
        Button4.enabled = true;

        B1text.text = "";
        B2text.text = "";
        B3text.text = "";
        B4text.text = "";

        switch (this.cardName)
        {
            case "TheGate":    

                switch(pathto)
                {
                    case "TheGate ":

                        Recit.text = paragraph("Alors que la pluie battante vous extenue dans vos perégrinations sur les routes sans fin de Landskøm, vous apercevez les larges portes d'une ville. Une athmosphère inquiétante se dégage des lieux. Vous voyez de mornes soldats pénétrant l'enceinte, probablement de retour de quelque pillage.. Vous ne savez si les habitants de la ville vous sont hostiles ou non, mais vous sentez que vous n'êtes pas le bienvenu.. Que voulez vous faire ?");

                        B1text.text = "S'approcher discretement de la ville..";
                        B2text.text = "Sortir de votre cachette et heler le garde";
                        B3text.text = "Rester caché pour quelques temps..";
                        B4text.text = "Poursuivre votre périple";

                    break;

                    case "TheGate 1":

                        tirage = rnd.Next(4);

                        if (tirage < 3)
                        {
                            Recit.text = paragraph("Alors que vous vous avancez furtivement de votre but, une voix sévère vient briser vos rêves de tavernes et de boisson. \"Qui va la ?\" Il semblerait que les gardes ne fassent pas mince affaire de leur besogne, ce soir.. ");

                            B1text.text = "Vous excuser de ce terrible malentendu et expliquer vos intentions pacifiques";
                            B2text.text = "Demander la permission de rentrer dans la ville";
                            B3text.text = "Vous présenter fièrement";
                            B4text.text = "S'enfuir tant qu'il est encore temps!";
                        }
                        else
                        {
                            path += '#';
                            Recit.text = paragraph("Un groupe de voyageurs s'approche de la ville, une occasion pour vous de vous mêler à la foule!");
                            B1text.text = "Continuer";
                            B2text.text = "Poursuivre votre voyage";

                            Button3.enabled = false;
                            Button4.enabled = false;
                        }
                    break;

                    case "TheGate 11":
                        path = "TheGate 1>";
                        Recit.text = paragraph("Les gardes ne semblent pas d'humeur à tergiverser. Sans doute avez vous interrompu une trépidante partie de cartes ?");

                        Continuer("Continuer");

                        break;

                    


                    case "TheGate 12":
                        Recit.text = paragraph("Un rictus se dessine sur le visage d'un des gardes. Entrer dans la ville ? Ah! Un r'negat comm' toi ? T'sais c'qu'on risque pour ça ? Par pour moins qu'deux écus! ");

                        B1text.text = "Accepter l'offre (coût : 2 or)";
                        B2text.text = "Refuser et poursuivre votre périple";
                        Button3.enabled = false;
                        Button4.enabled = false;

                        break;

                    case "TheGate 121":
                        path = "TheGate 1#1";
                        nextDialogue(path);
                        break;

                    case "TheGate 122":
                        Endcard();
                        return;

                    case "TheGate 13":
                        path = "TheGate 1>";
                        Recit.text = paragraph("Même dans l'embarras où vous êtes plongés, vous vous efforcez de ne pas perdre la face. Vous expliquez posément aux gardes ce qui vous ammène ici, en espérant qu'ils soient recéptifs à vos malheurs.");
                        Continuer("Continuer");

                        break;

                    case "TheGate 14":
                        Recit.text = paragraph("Voyant les gardes s'approcher, vous vous enfuyez à grandes enjambées. Ces derniers ne prennent pas le temps de poursuivre la vermine que vous êtes à leur yeux, et reprennent leur partie de cartes..");
                        Continuer("Poursuivre votre périple");

                        break;

                    case "TheGate 141":
                        Endcard();
                        break;


                    case "TheGate 1>1":
                        Recit.text = paragraph("Les gardes vous dévisagent avec méfiance.. Jouer la carte de la sincérité suffira-t-il à faire oublier ces présentations peu avantageuses ? Pour l'heure, la seule réponse que vous obtenez de la garde est un silence glacial. \"Pourquoi qu'on vous laisserait v'nir, vagabond ? Vous autres n'semez qu'des problèmes sur vot' chemin");

                        B1text.text = "Tenter d'attirer l'empathie du garde";
                        B2text.text = "Intimider les gardes";
                        B3text.text = "Payer l'entrée dans la ville (coût : 1 or)";
                        B4text.text = "Renoncer à entrer dans la ville et pousuivre votre voyage";
                        break;

                    case "TheGate 1>11":

                        // jet de charisme

                       
                        //réussite -> 

                        path = "TheGate 1#1";
                        nextDialogue(path);
                        return;
                        

                    case "TheGate 1>12":

                        // jet de charisme + force

                        //réussite -> 

                        path = "TheGate 1#1";
                        nextDialogue(path);
                        return;


                    case "TheGate 1>13":
                        // -1 or

                        path = "TheGate 1#1";
                        nextDialogue(path);
                        return;

                    case "1>14":
                        Endcard();
                        return;

                    case "TheGate 2":
                        Recit.text = paragraph("Attendant, seul dans la lumière, l'apparition de votre interlocuteur, un vent glacial vous secoue de toutes parts. Des bruits de pas. En rythme. Un régiment de gardes sort de la grande porte, et vient s'approcher de vous..");
                        B1text.text = "Expliquer vos intentions pacifiques";
                        B2text.text = "Demander la permission de rentrer dans la ville";
                        B3text.text = "Vous présenter fièrement";
                        B4text.text = "S'enfuir tant qu'il est encore temps!";

                        break;

                    case "TheGate 21":
                        path = "TheGate 11";
                        nextDialogue(path);
                        return;

                    case "TheGate 22":
                        path = "TheGate 12";
                        nextDialogue(path);
                        return;

                    case "TheGate 23":
                        path = "TheGate 13";
                        nextDialogue(path);
                        return;

                    case "TheGate 24":
                        path = "TheGate 14";
                        nextDialogue(path);
                        return;

                    case "TheGate 3":

                        tirage = rnd.Next(2);

                        if (tirage == 0)
                        {

                            Recit.text = paragraph("Après une attente, qui sous la pluie vous parut bien longue, vous entendez le bruit rocailleux d'une cariole sur la route. Vous risquez un regard hors de votre cachette. Une caravane de marchand. Les chevaux s'arretent soudain dans un enfer de henissements.  \"Une roue a du sauter\", vous pensez.");

                            B1text.text = "Attendre qu'il descende remettre la roue pour se cacher dans les marchandises";
                            B2text.text = "Proposer votre aide";
                            B3text.text = "Le poignarder tant que ses yeux sont occupés..";
                            B4text.text = "Ne rien faire";
                        }
                        else
                        {
                            path += '#';
                            Recit.text = paragraph("Un rongeur, une relève, deux gardes parlant de femmes.. Vous ne ressentez que le froid et l'impression d'avoir attendu pour rien.");

                            Continuer("Continuer");
                        }
                        break;


                    case "TheGate 31":
                        //jet agi
                        // -> réussite
                        path = "TheGate 1#";
                        Continuer("Entrer dans la ville");
                        break;

                    case "TheGate 32":
                        //jet char
                        // -> réussite
                        path = "TheGate 1#";
                        Continuer("Entrer dans la ville");
                        break;

                    case "TheGate 33":
                        Recit.text = paragraph("Votre méfait accompli vous pillez le cadavre encore chaud du marchand, et prenez la fuite avant que la caravane immobile attire l'attention des gardes..");
                        Continuer("Continuer");
                        break;

                    case "TheGate 34":
                        Recit.text = paragraph("Le marchand remet sa route en place et reprend son chemin. Vous avez manqué l'occasion.. Il est temps de reprendre votre voyage");
                        Continuer("Poursuivre votre périple");

                        break;

                    case "TheGate 341":
                        Endcard();
                        return;

                    case "TheGate 331":
                        Endcard();
                        break;

                    case "TheGate 3#1":
                        playCard();
                        break;

                    case "TheGate 1#1":
                        Recit.text = paragraph("Vous parvenez à entrer dans la ville sans encombre, mais souhaitez ne pas vous y éterniser.. Que voulez vous faire ?");
                        B1text.text = "Aller à la taverne: (coût: 3 or)";
                        B2text.text = "Vous rendre au temple pour vous recueillir";
                        B3text.text = "Profiter de l'occasion pour panser vos blessures";
                        B4text.text = "Aller à l'armurerie pour affuter votre arme";

                        break;

                    case "TheGate 1#11":
                        Recit.text = paragraph("L'alcool vient réchauffer votre sang durement éprouvé, vous voyez dans l'écume des pintes le reflet joyeux de vos dernières aventures.");
                        Continuer("Sortir de la ville et poursuivre votre voyage");
                        path = "TheGate 1#1>";

                        break;

                    case "TheGate 1#12":
                        Recit.text = paragraph("Dans l'intimité de l'autel, vous trouvez le réconfort et une présence bienfaitrice. Est-ce un message des Grands, porteur de fortune ? Seul l'avenir vous le dira.");
                        Continuer("Sortir de la ville et poursuivre votre voyage");
                        path = "TheGate 1#1>";

                        break;

                    case "TheGate 1#13":
                        Recit.text = paragraph("Assis à l'abri sous l'arche d'une poterne, vous entreprenez de confectionner un pansement pour couvrir vos plaies. ");
                        Continuer("Sortir de la ville et poursuivre votre voyage");
                        path = "TheGate 1#1>";
                        break;

                    case "TheGate 1#14":
                        Recit.text = paragraph("L'armurier vous laisse utiliser sa meule par vous même. Vous vous donnez à coeur joie de ranimer le tranchant des beaux jours de votre arme.");
                        Continuer("Sortir de la ville et poursuivre votre voyage");

                        path = "TheGate 1#1>";
                        break;

                    case "TheGate 1#1>1":
                        Endcard();
                        break;

                    

                    case "TheGate 4":
                        Endcard();
                        return;


                }
                break;



            case "Gobelins!":
                switch (path)
                {
                    case "Gobelins! ":
                        Recit.text = paragraph("Une horde de gobelins vous attaque! Aux armes !");
                        Continuer("Combattre!");
                        break;
                    case "Gobelins! 1":
                        Endcard();
                        break;
                }
                break;
        }

        clicked = false;
        StartCoroutine(WaitForClick());


    }


    public void Endcard()
    {
        s.canMove = true;
        Parchemin.SetActive(false);
        path = "";
    }
    /*

    private string getFirstWord(string str)
    {
        int compteur = 0;
        string word = "";
        int L = str.Length;

        while (str[compteur] != ' ' && compteur < L)
        {
            word += str[compteur];
            compteur++;
        }
        return word;
    }
    */

    public bool Dial()
    {

                if (a) 
                {
            path += "1";
                }
                else if (b)
                {
            path += "2";
                }
                else if (c)
                {
            path += "3";
                }
                else if (d) 
                {
            path += "4";
                }


        a = false;
        b = false;
        c = false;
        d = false;

        return true;
              
    }
    
    private void Continuer(string str)
    {
        B1text.text = str;
        Button2.enabled = false;
        Button3.enabled = false;
        Button4.enabled = false;
    }


        // Update is called once per frame
        void Update()
    {
        if (this.transform.position.x == Player.transform.position.x && this.transform.position.z == Player.transform.position.z)
        {

            sr.sprite = Image;
            if (isDone && !stch)
            {
                s.canMove = true;
                stch = true;
                Parchemin.gameObject.SetActive(false);
            }

            //STAPLE ENDS

            else if (!isDone && !cardPlaying)
            {
                Parchemin.gameObject.SetActive(true);
                playCard();

            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                Parchemin.gameObject.SetActive(false);
                isDone = true;
            }    
        }        
        else
        {
            stch = false;
        }
    }

    //STAPLE


    private void OnMouseEnter()
    {
         sr.sprite = Image; // CHANEGE NAME
    }
    private void OnMouseExit()
    {
          sr.sprite = null;
    }


    //STAPLE ENDS

    private void PressButton1()
    {
        if (cardPlaying)
        {
            a = true;
            clicked = true;
        }
    }
    private void PressButton2()
    {
        if (cardPlaying)
        {
            b = true;
            clicked = true;
        }
    }
    private void PressButton3()
    {
        if (cardPlaying)
        {
            c = true;
            clicked = true;
        }
    }
    private void PressButton4()
    {
        if (cardPlaying)
        {
            d = true;
            clicked = true;
        }
    }


}
