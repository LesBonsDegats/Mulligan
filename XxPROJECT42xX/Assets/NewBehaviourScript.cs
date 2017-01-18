using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{

    public List<int> eligibles = new List<int>();
    public List<int> cases = new List<int>();
    public List<int> revealed = new List<int>();

    public GameObject CardStart;

    public GameObject CardT;
    public GameObject CardP;
    public GameObject CardR;

    public int nbreT;
    public int nbreR;

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;

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
        iniLvl(6);


    }

    public void iniLvl(int nbreCases)
    {
        System.Random rnd = new System.Random();


        int decalagex = 4;
        int decalagez = 2;

        cases.Remove(1010);
        revealed.Add(1010);
        int bossPos = CreateLvl(nbreCases);
        Instantiate(CardStart, new Vector3(10 * decalagex, 1, 10 * decalagez), Quaternion.identity, floor.transform);


        int nbreCasesAReveal = floorlvl / 4;
        if (nbreCasesAReveal > 5)
        {
            nbreCasesAReveal = 5;
        }

        int R = 0;
        int P = 0;

        int T = rnd.Next(1, nbreCasesAReveal);
        if (T > 2)
        {
            T = 2;
        }
        nbreCasesAReveal -= T;

        if (nbreCasesAReveal > 0)
        {
            R = rnd.Next(nbreCasesAReveal);
            nbreCasesAReveal -= R;

            if (nbreCasesAReveal > 0)
            {
                // P = nbreCasesAReveal;
                P = 1;
            }
        }


        revealIni(T, R, P);

        foreach (int i in cases)
        {
            Instantiate(go, new Vector3((i / 100) * decalagex, 1, (i % 100) * decalagez), Quaternion.identity, floor.transform);
        }
        Instantiate(bossCard, new Vector3((bossPos / 100) * decalagex, 1, (bossPos % 100) * decalagez), Quaternion.identity, floor.transform);
        revealed.Add(bossPos);


        cameraPos(cases);
        inventory.transform.position = new Vector3(camera.transform.position.x, 18, camera.transform.position.z - 3);

        token.transform.position = (new Vector3(10 * decalagex, 1, 10 * decalagez));

        
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

        return pos;
    }

    public void revealIni(int T, int R, int P)
    {
        
        int nbreCasesAReveal = floorlvl /4;

        GameObject TRP = CardStart;


        int elu = 0;
        int casesCount = cases.Count;


        while (T+R+P > 0)
        {
            System.Random rnd = new System.Random();

            int tirage = rnd.Next(casesCount);
            elu = cases[tirage];

            cases.Remove(elu);
            casesCount--;

            if (T > 0)
            {
                Instantiate(CardT, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
                T--;
            }
            else
            {
                if (R > 0)
                {
                    Instantiate(CardR, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
                    R--;
                }
                else if (P > 0)
                {
                    Instantiate(CardP, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
                    P--;
                }
                


                //Instantiate(TRP, new Vector3(elu / 100 * 4, 1, elu % 100 * 2), Quaternion.identity, floor.transform);
              
            }


        }
    }


    public bool reveal(int x, int z)
    {

        GameObject newcard = Card1;

        if (isIn(x * 100 + z, revealed))
        {
            return false;
        }
        else
        {
                System.Random rnd = new System.Random();
                int tirage = rnd.Next(1, 7);

                switch (tirage)
                {
                    case 1:
                        newcard = Card1;
                        break;
                    case 2:
                        newcard = Card2;
                        break;
                    case 3:
                        newcard = Card3;
                        break;
                    case 4:
                        newcard = Card4;
                        break;
                    case 5:
                        newcard = Card5;
                        break;
                    case 6:
                        newcard = Card6;
                        break;
                }

                Instantiate(newcard, new Vector3(x * 4, 1, z * 2), Quaternion.identity, floor.transform);

                revealed.Add((int)(x * 100F + z));
                return true;
            }
        }

   

    // Update is called once per frame
    void Update()
    { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

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

            floorlvl += 2;

           iniLvl(floorlvl);
        }

     
    }
}
