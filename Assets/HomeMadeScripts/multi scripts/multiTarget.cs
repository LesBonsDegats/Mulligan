using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTarget : MonoBehaviour {

    public int life;
    private Rigidbody r;

    // Use this for initialization
    void Start()
    {
        r = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
           
            if (loseLife(10))
            {
                Destroy(this.gameObject);
                Application.LoadLevel("deathscreen");

            }
            GameObject parent = other.gameObject;
            while (parent.transform.parent != null) //?
            {
                parent = parent.transform.parent.gameObject;
            }
            Vector3 distance = parent.transform.position - this.transform.position;
            r.AddForce(new Vector3(-distance.x, 0, -distance.z) * 100000);

        }
    }

    private bool loseLife(int dmg)
    {
        life -= dmg;
        return (life <= 0);
    }
}