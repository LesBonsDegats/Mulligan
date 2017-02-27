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

    private IEnumerator delaiAttaque1;

	// Use this for initialization
	void Start () {
        delaiAttaque1 = attackTime(0, 50);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) 
        {

            if (isAttacking)
            {
                hit.SetTrigger("hit2");
                isAttacking = true;
                isAttacking1 = true;
                isAttacking2 = true;

                StopAllCoroutines();
                StartCoroutine(attackTime(1, 50));

            }
            else
            {

                //   if (!isAttacking)
                //    {
                hit.SetTrigger("hit1");
                isAttacking = true;
                isAttacking1 = true;


                StartCoroutine(attackTime(0, 50));
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
    IEnumerator attackTime(int attaqueid, int attackspeed)
    {

        bool swtch = false;
        while (true)
        {
            if (swtch)
            {


                switch (attaqueid)
                {
                    case 0:
                        isAttacking1 = false;
                        isAttacking = false;
                        compteur++;
                        break;
                    case 1:
                        isAttacking = false;
                        isAttacking1 = false;
                        isAttacking2 = false;
                        break;
                }

                StopAllCoroutines();
            }

            swtch = true;

            yield return new WaitForSeconds(0.3f);
        }
    }
}
