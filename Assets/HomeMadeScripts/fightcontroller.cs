using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightcontroller : MonoBehaviour
{

    public NewBehaviourScript s;

    public Animator hit;

    public int compteur = 0;
    public int charge = 0;

    public bool isAttacking = false;

    public bool isAttacking1 = false;
    public bool isAttacking2 = false;

    public bool isCharging = false;
    public bool isAttackingCharged = false;

    public float aSpeed;
    public int BladeDmg;
    public int BluntDmg;
    public int MagicDmg;
    public int ElementalDmg;
    public int Armor;

    public int Stamina;
    public int maxStamina;

    public int Mana;
    public int maxMana;


    // Use this for initialization
    void Start()
    {
        aSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && !isCharging)
        {
            isCharging = true;
            hit.SetTrigger("charge");
            StartCoroutine("ChargeAttack");

        }

        if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;
            StopCoroutine("ChargeAttack");
            //coup chargé
            if (charge >= 10)
            {
                hit.SetTrigger("ChargedAttack");
                isAttackingCharged = true;
                StartCoroutine(Attacktime(aSpeed));
                StartCoroutine("combo");
                


            }
            else
            {

                //coup pas chargé
                if (isAttacking1)
                {
                    hit.speed = aSpeed;
                    hit.SetTrigger("hit2");
                    isAttacking1 = false;
                    isAttacking2 = true;
                    StopAllCoroutines();
                    StartCoroutine("Attacktime", aSpeed);
                }
                else
                {
                    hit.speed = aSpeed;
                    hit.SetTrigger("hit1");
                    isAttacking1 = true;
                    isAttacking2 = false;
                    StartCoroutine("Attacktime", aSpeed);
                }


                StartCoroutine("combo");
                isAttacking = isAttacking1 || isAttacking2;

            }
            charge = 0;
        }


    }


    IEnumerator Attacktime(float attackspeed)
    {
        bool swtch = false;
        bool fix = true;
        while (fix)
        {
            if (swtch)
            {
                isAttacking = false;

                fix = false;
                StopCoroutine("Attacktime");
            }

            swtch = true;

            yield return new WaitForSeconds(5 / attackspeed);
        }
    }

    IEnumerator ChargeAttack()
    {
        while (true)
        {
            charge++;
            yield return new WaitForSeconds(0.1f);
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

                fix = false;
                StopCoroutine("combo");
            }

            swtch = true;

            yield return new WaitForSeconds(1);
        }
    }
}
