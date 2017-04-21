﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobAnimation : MonoBehaviour {

    private Animation Anim;

    public fightcontroller player;

    public int[] Agenda;
    // 0 -> approachPlayer
    // 1 -> strafeAroundPlayer
    // 2 -> dashOnPlayer
    // 3 -> attackPlayer
    // 4 -> blockPlayer
    // 5 -> 
    public dashOnPlayer dashOnPlayer;
    public attackPlayer attackPlayer;

    public bool isDoingSomething;
    public bool isDashing;

    //cooldowns
    public bool canDash;
    public bool canAttack;

    public List<Coroutine> SpanList;
    public List<Coroutine> CdList;

	// Use this for initialization
	void Start () {

        SpanList = new List<Coroutine>();
        CdList = new List<Coroutine>();

        Agenda = new int[5];
        Anim = this.GetComponent<Animation>();
        canDash = true;
        canAttack = true;
        StartCoroutine(getNextAction());
	}
	
	// Update is called once per frame
	void Update () {
        if (isDashing)
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * dashOnPlayer.speed);
        }

	}

    IEnumerator getNextAction()
    {
        while (true)
        {

            isDoingSomething = !Anim.IsPlaying("combat_idle");
            if (!isDoingSomething)
            {
                GetCommands();
                ExecuteBestCommand();
                Agenda = new int[5];
               // Debug.Log("ticked");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }


    public void GetCommands()
    {
        Agenda[0] = 1;
        Agenda[3] = 0;
        Agenda[4] = 0;


        ////////////////////////////////////////////////////
        if (attackPlayer != null)
        {
            if (attackPlayer.getCommand() && canAttack)
            {
                Agenda[3] = 1;
            }
        }
        else
        {
            Agenda[3] = 0;
        }
        ////////////////////////////////////////////////////
        if (dashOnPlayer != null )
        {
            if (dashOnPlayer.getCommand() && canDash)
            {
                Agenda[2] = 1;
            }
        }
        else
        {
            Agenda[2] = 0;
        }
        //////////////////////////////////////////////////////
    }
    public void ExecuteBestCommand()
    {
        System.Random rnd = new System.Random();

        //on cherche l'action la plus intéressante


        // approach action à intéret la plus basse, valeur par défaut
        Agenda[0] = 1; //useless mais pour la clarté on laisse


        // strafe AroundPlayer, en conflit avec dashOnPlayer et ayant pour but de délayer le dash (créer l'effet de surprise)
        Agenda[1] *= 2;


        // dashOnPlayer, mieux que approach, moins bon que attack
        Agenda[2] *= 2;

        //départageons Dash et Strafe

        int tirage = rnd.Next(3);
        if (tirage == 0)
            Agenda[1] = 0;
        else
            Agenda[2] = 0; // 1 chance sur 3 de Dash


        //attack, action à prioritétiser, mais en conflit avec block
        Agenda[3] *= 3;
        Agenda[4] *= 2;
        if (player.isAttacking)
            Agenda[4] *= 2;

        int index = getMaxValueIndex(Agenda);

        switch (index)
        {
            case (0):
                //approach();
                break;
            case (1):
                //strafe();
                break;
            case (2):
                dash();
                break;
            case (3):
                attack();
                break;
            case (4):
               // block();
                break;
            default:
                dash();
                break;
        }
    }


    public int getMaxValueIndex(int[] arr)
    {
        int max = 0;
        int L = arr.Length;

        if (L > 1)
        {
            for (int i = 1; i < L; i++)
            {
                if (arr[i] > arr[max])
                    max = i;
            }
            return max;
        }
        else return 0;


    }

    public void playAnim(string str)
    {
        Anim.Play(str);
    }

    IEnumerator Cooldown (float seconds, string action)
    {
        bool swtch = false;
        while (true)
        {
            if (swtch)
            {
                switch(action) // :))))))))
                {
                    case ("dashOnPlayer"):
                        canDash = true;
                        break;
                    case ("attackPlayer"):
                        canAttack = true;
                        break;
                }
                foreach (Coroutine co in CdList)
                  StopCoroutine(co);
            }
            swtch = true;
            yield return new WaitForSeconds(seconds);
        }
    }

    public void dash()
    {
        isDashing = true;
        canDash = false;
        CdList.Add(StartCoroutine(Cooldown(4, "dashOnPlayer")));
        SpanList.Add(StartCoroutine(Span(Anim["run"].length)));
        playAnim("run");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            isDashing = false;
        }
    }

    public void attack()
    {
        canAttack = false;
        CdList.Add(StartCoroutine(Cooldown(2, "attackPlayer")));
        CdList.Add(StartCoroutine(Span(Anim["attack1"].length)));
        attackPlayer.weapon.tag = "weaponAttack";

        playAnim("attack1");
    }

    IEnumerator Span(float seconds)
    {
        bool swtch = false;
        while (true)
        {
            if (swtch)
            {
                Debug.Log("Reset");
                playAnim("combat_idle");

                foreach (Coroutine co in SpanList)
                    StopCoroutine(co);
            }
            swtch = true;
            yield return new WaitForSeconds(seconds);
        }

    }
}