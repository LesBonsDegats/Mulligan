using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{

    public List<int> eligibles = new List<int>();
    public List<int> cases = new List<int>();
    public List<int> revealed = new List<int>();

    public GameObject ShowCard;
    public SpriteRenderer sr;

    public GameObject CardStart;

    public GameObject CardT;
    public GameObject CardP;
    public GameObject CardR;

    public int nbreT = 0;
    public int nbreR = 0;
    public int nbreP = 0;
    public List<int> possibilities = new List<int>();

    public GameObject TCard1;
    public GameObject TCard2;
    public GameObject RCard1;
    public GameObject RCard2;
    public GameObject PCard1;
    public GameObject PCard2;

    public GameObject floor;

    public GameObject camera;

    public GameObject inventory;

    public GameObject go;
    public GameObject bossCard;
    public GameObject token;

    public bool debut = true;

    public int floorlvl = 6;

    // Use this for initialization
    void Start()
    {
         SpriteRenderer sr = ShowCard.GetComponent<SpriteRenderer>();
        iniLvl(6);


    }

    public void iniLvl(int nbreCases)
    {
        System.Random rnd = new System.Random();


        int decalagex = 4;
        int decalagez = 2;

        int nbreCards = nbreCases - 1;

        // set nbreT et nbre R

        nbreT = rnd.Next(1, nbreCases / 4 + 1);
        nbreR = rnd.Next(1, nbreCases / 4 + 1);
        nbreP = nbreCases - nbreR - nbreT - 1;

        if (nbreT > 0)
            possibilities.Add(1);
        if (nbreR > 0)
            possibilities.Add(2);
        if (nbreP > 0)
            possibilities.Add(3);


        //fin set nbre T et set nbreR




        revealed.Add(1010);
        int bossPos = CreateLvl(nbreCases);
        Instantiate(CardStart, new Vector3(10 * decalagex, 1, 10 * decalagez), Quaternion.identity, floor.transform);


        //reveal initiale

        revealIni(nbreT, nbreR, nbreP);

        /*
        int nbreCasesAReveal = floorlvl / 4;
        if (nbreCasesAReveal > 5)
        {
            nbreCasesAReveal = 5;
        }

        int R = 0;
        int P = 0;


        
        int T = rnd.Next(1, nbreCasesAReveal);
        if (T > nbreT)
        {
            T = nbreT;
            nbreCasesAReveal -= T;
        }
        if (nbreCasesAReveal > 0)
        {
            R = rnd.Next(nbreCasesAReveal);
            if (R > nbreR)
            {
                R = nbreR;
            }

            nbreCasesAReveal -= R;


            if (nbreCasesAReveal > 0)
            {
                P = nbreCasesAReveal;

            }
        }

        revealIni(T, R, P);

        */

        //fin reveal initiale

        //pose des cartes face cachée

        foreach (int i in cases)
        {
            Instantiate(go, new Vector3((i / 100) * decalagex, 1, (i % 100) * decalagez), Quaternion.identity, floor.transform);
        }
        Instantiate(bossCard, new Vector3((bossPos / 100) * decalagex, 1, (bossPos % 100) * decalagez), Quaternion.identity, floor.transform);
        revealed.Add(bossPos);


        cameraPos(cases);
        inventory.transform.position = new Vector3(camera.transform.position.x, 18, camera.transform.position.z - 3);

        token.transform.position = (new Vector3(10 * decalagex, 1, 10 * decalagez));

        //fin pose des cartes face cachée


    }

    public bool isAdj(GameObject card1, RaycastHit card2)
    {
        int decalagex = 4;
        int decalagez = 2;

        bool a = (card1.transform.position.x == card2.transform.position.x + decalagex) || (card1.transform.position.x == card2.transform.position.x - decalagex);
        bool b = (card1.transform.position.z == card2.transform.position.z + decalagez) || (card1.transform.position.z == card2.transform.position.z - decalagez);
        return (a ^ b) && Math.Abs((card1.transform.position.x - card2.transform.position.x)) < decalagex + 1 && Math.Abs((card1.transform.position.z - card2.transform.position.z)) < decalagez + 1;
    }

    public void cameraPos(List<int> cases)
    {
        int sumx = 1;
        int sumz = 1;

        int decalagex = 4;
        int decalagez = 2;

        foreach (int i in cases)
        {
            sumx += i / 100;
            sumz += i % 100;

            int L = cases.Count;

            camera.transform.position = new Vector3(sumx * decalagex / L, 22, sumz * decalagez / L - 5);

        }




    }


    public static bool isIn(int e, List<int> list)
    {
        bool ret = false;
        foreach (int i in list)
        {
            if (e == i)
            {
                ret = true;
            }
        }

        return ret;
    }


    public int CreateLvl(int nbreCases)
    {
        int pos = 1010;
        int L = 0;
        int tirage = 0;
        System.Random rnd = new System.Random();

        cases.Add(1010);

        while (nbreCases > 0)
        {


            if (!isIn(pos - 1, cases))
            {
                eligibles.Add(pos - 1);
            }
            if (!isIn(pos + 1, cases))
            {
                eligibles.Add(pos + 1);
            }
            if (!isIn(pos + 100, cases))
            {
                eligibles.Add(pos + 100);
            }
            if (!isIn(pos - 100, cases))
            {
                eligibles.Add(pos - 100);
            }

            L = eligibles.Count;


            tirage = rnd.Next(L - 1);

            if (!isIn(eligibles[tirage], cases))
            {

                pos = eligibles[tirage];
                if (nbreCases > 1)
                {
                    cases.Add(eligibles[tirage]);
                }
                nbreCases--;
            }



        }
        cases.Remove(1010);
        return pos;
    }

    public void revealIni(int T, int R, int P)
    {
        int casesCount = cases.Count;
        int nbreCasesAReveal = floorlvl / 4;
        int elu;
        char tirage;

        int tirageCases = 0;

        int PossCount = possibilities.Count;

        System.Random rnd = new System.Random();
        GameObject TRP = CardStart;

        while (nbreCasesAReveal > 0 && PossCount > 0)
        {
            tirage = TRPchoose();
            tirageCases = rnd.Next(casesCount);
            elu = cases[tirageCases];

            revealed.Add(elu);
            cases.Remove(elu);
            casesCount--;
            nbreCasesAReveal--;

            switch (tirage)
            {
                case ('T'):
                    Instantiate(CardT, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
                    PossCount--;
                    break;
                case ('R'):
                    Instantiate(CardR, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
                    PossCount--;
                    break;
                case ('P'):
                    Instantiate(CardP, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
                    PossCount--;
                    break;



            }

            //   Instantiate(TRP, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);


        }

    }


    public char TRPchoose()
    {
        System.Random rnd = new System.Random();


        int tirage = rnd.Next(possibilities.Count);

        switch (possibilities[tirage])
        {
            case (1):
                nbreT--;
                if (nbreT < 1)
                    possibilities.Remove(1);
                return 'T';
            case (2):

                nbreR--;
                if (nbreR < 1)
                    possibilities.Remove(2);
                return 'R';
            case (3):

                nbreP--;
                if (nbreP < 1)
                    possibilities.Remove(3);
                return 'P';


        }
        return ' ';

    }


    public bool reveal(int x, int z)
    {
        int tirage = 0;
        char TRPtirage = ' ';
        GameObject newcard = CardStart;

        if (isIn(x * 100 + z, revealed))
        {
            return false;
        }
        else
        {
            System.Random rnd = new System.Random();


            tirage = rnd.Next(1, 3);
            TRPtirage = TRPchoose();



            switch (TRPtirage)
            {
                case 'T':

                    //reveal T
                    tirage = rnd.Next(1, 3);

                    switch (tirage)
                    {
                        case 1:
                            newcard = TCard1;
                            break;
                        case 2:
                            newcard = TCard2;
                            break;
                    }
                    break;

                case 'R':
                    //reveal R
                    tirage = rnd.Next(1, 3);

                    switch (tirage)
                    {
                        case 1:
                            newcard = RCard1;
                            break;
                        case 2:
                            newcard = RCard2;
                            break;
                    }



                    break;

                case 'P':
                    //reveal P
                    tirage = rnd.Next(1, 3);

                    switch (tirage)
                    {
                        case 1:
                            newcard = PCard1;
                            break;
                        case 2:
                            newcard = PCard2;
                            break;
                    }
                    break;
            }
        }
        Instantiate(newcard, new Vector3(x * 4, 1, z * 2), Quaternion.identity, floor.transform);

        revealed.Add((int)(x * 100F + z));
        return true;
    }




    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Ray CheckBelowHit = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

       if (Physics.Raycast(ray, out hit, 100.0F))
        {



        }


        if (Input.GetMouseButtonDown(0))
        {


            if (Physics.Raycast(ray, out hit, 100.0F))
            {
                if (isAdj(token, hit))
                {
                    token.transform.position = hit.transform.position;
                    if (!isIn((int)(hit.transform.position.x) * 100 / 4 + (int)(hit.transform.position.z) / 2, revealed))
                    {

                        float x = hit.transform.position.x / 4F;
                        float z = hit.transform.position.z / 2F;
                        bool a = reveal((int)x, (int)z);

                        if (a)
                        {
                            hit.collider.gameObject.SetActive(false);
                        }
                    }


                }
            }

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in floor.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

            eligibles.Clear();
            cases.Clear();
            revealed.Clear();
            possibilities.Clear();

            if (floorlvl < 14)
                floorlvl += 2;



            iniLvl(floorlvl);
        }




    }

}


