using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Collider weapon;
    public fightcontroller f;

    public int life;

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
            f.weapon.enabled = false;
            bool isDead = loseLife(10);
            if (isDead)
            {
                this.gameObject.SetActive(false);
            }

            this.transform.Translate(new Vector3(0, 0, -2));

        }
    }

    private bool loseLife(int dmg)
    {
        life -= dmg;

        return (life < 0);
    }
}
