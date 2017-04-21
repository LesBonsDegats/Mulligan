using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dashOnPlayer : MonoBehaviour {

    public GameObject player;
    public int speed;
    public int distanceMin;
    public int distanceMax;


 
	// Use this for initialization
	void Start () {
	}


    public bool getCommand()
    {
        return (isCloseEnough());
    }

    public bool isCloseEnough()
    {
        float posx = player.transform.position.x;
        float posz = player.transform.position.z;

        float distance = (float)Math.Sqrt((posx - transform.position.x) * (posx - transform.position.x) + (posz - transform.position.z) * (posz - transform.position.z));

        return (distance < distanceMax) && (distance > distanceMin);
    }


    /*
	// Update is called once per frame
	void Update () {

        
        closeEnough = isCloseEnough();

        if (closeEnough && canDash && !mobAnim.Anim.IsPlaying("attack1")) 
            dash();

        if (isDashing)// && (float)Math.Sqrt((mobTarget.transform.position.x - transform.position.x) * (mobTarget.transform.position.x - transform.position.x) + (mobTarget.transform.position.z - transform.position.z) * (mobTarget.transform.position.z - transform.position.z)) > 1)
        {
            
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            
        }
        

     //   transform.Translate(Vector3.forward * Time.deltaTime);

        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
          //  Debug.Log("player hit");
            isDashing = false;
            mobAnim.playAnimation("attack2");
        }
    }

   
    public void dash()
    {
        //mobTarget.transform.parent = null;
        StartCoroutine("dashCd");
        StartCoroutine("dashSpan");
        isDashing = true;
        mobAnim.playAnimation("run");
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
                mobAnim.playAnimation("combat_idle");
             //   mobTarget.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
              //  mobTarget.transform.parent = player.transform;
            }

            swtch = true;
            yield return new WaitForSeconds(1.5f);
        }

    }
    */

}
