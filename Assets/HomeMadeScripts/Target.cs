using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int life;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "weaponAttack")
        {
            collision.collider.gameObject.tag = "weapon";
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

        Debug.Log(this.gameObject.name + " lost " + dmg.ToString() + " health");
        return (life < 0);
    }
}
