using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Collider weapon;
    public fightcontroller f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == weapon && f.isAttacking)
        {
            this.gameObject.SetActive(false);

        }
    }
}
