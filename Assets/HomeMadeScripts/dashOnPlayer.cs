using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dashOnPlayer : MonoBehaviour {

    public GameObject player;
    public Collider playerCollider;

    public bool closeEnough;
    public bool canDash = true;
    public bool isDashing = false;
    public int speed;


    public Vector3 targetPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        closeEnough = isCloseEnough();

        if (closeEnough && canDash)
            dash();

        if (isDashing)
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }
        

     //   transform.Translate(Vector3.forward * Time.deltaTime);

        
	}

    public bool isCloseEnough()
    {
        float posx = player.transform.position.x;
        float posz = player.transform.position.z;

        float distance = (float)Math.Sqrt((posx - transform.position.x) * (posx - transform.position.x) + (posz - transform.position.z) * (posz - transform.position.z));
        
    return (distance < 7);
    }

    public void dash()
    {
        targetPos = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
        StartCoroutine("dashCd");
        StartCoroutine("dashSpan");
        isDashing = true;
        canDash = false;
    }

    IEnumerator dashCd()
    {
        bool swtch = false;

        while (true)
        {

            if (swtch)
            {
                canDash = true;
                StopCoroutine("dashCd");
            }

            swtch = true;
        yield return new WaitForSeconds(3);
        }
    }

    IEnumerator dashSpan()
    {
        bool swtch = false;

        while (true)
        {

            if (swtch)
            {
                isDashing = false;
                StopCoroutine("dashSpan");
            }

            swtch = true;
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == playerCollider)
        {
            isDashing = false;
        }

    }


}
