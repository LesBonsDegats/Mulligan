using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightcontroller : MonoBehaviour {

    public NewBehaviourScript s;

    public Animator hit;

    public int compteur = 0;

    public bool isAttacking = false;

    public bool isAttacking1 = false;
    public bool isAttacking2 = false;
    public bool isAttacking3 = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) 
        {
/*
            if (isAttacking2)
            {
                hit.SetTrigger("hit3");
                isAttacking = true;
                isAttacking1 = false;
                isAttacking2 = false;
                isAttacking3 = true;

                StopAllCoroutines();
                StartCoroutine(combo());
                StartCoroutine(Attacktime(6.67f));

            }

        */
            if (isAttacking1)
            {
                hit.SetTrigger("hit2");
                isAttacking = true;
                isAttacking1 = false;
                isAttacking2 = true;
                isAttacking3 = false;

                StopAllCoroutines();
                StartCoroutine("combo");
                StartCoroutine("Attacktime",6.67f);

            }
            else
            {

                //   if (!isAttacking)
                //    {
                hit.SetTrigger("hit1");
                isAttacking = true;
                isAttacking1 = true;
                isAttacking2 = false;
                isAttacking3 = false;

                StartCoroutine("combo");
                StartCoroutine("Attacktime",6.67f);
            }
      //      }

            /*
            else if (isAttacking1)
            {
                hit.SetTrigger("hit2");
                isAttacking2 = true
                StartCoroutine(coroutine);
            }
            else if (isAttacking2)
            {
                hit.SetTrigger("hit3");
                isAttacking3 = true;
            }

            isAttacking = true;

    */

        }


	}


    IEnumerator Attacktime (float attackspeed)
    {
        bool swtch = false;
        bool fix = true;
        while (fix)
        {
            if (swtch)
            {
                compteur++;
                isAttacking = false;

                fix = false;
                StopCoroutine("Attacktime");
            }

            swtch = true;

            yield return new WaitForSeconds(1/attackspeed);
        }




    }


    IEnumerator combo()
    {

        bool swtch = false;
        bool fix = true;
        while (fix)
        {
            if (swtch)
            {

 
                isAttacking = false;
                isAttacking1 = false;
                isAttacking2 = false;
                isAttacking3 = false;

                fix = false;
                StopCoroutine("combo");
            }

            swtch = true;

            yield return new WaitForSeconds(1);
        }
    }
}
