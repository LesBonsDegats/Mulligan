using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiTarget : MonoBehaviour {

    public int life;
    private Rigidbody r;
    private PhotonView view;
    // Use this for initialization
    void Start()
    {
        r = this.GetComponent<Rigidbody>();
        view = this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            GameObject parent = other.gameObject;
            while (parent.transform.parent != null) //?
            {
                parent = parent.transform.parent.gameObject;
            }
            Vector3 distance = parent.transform.position - this.transform.position;
            r.AddForce(new Vector3(-distance.x, 0, -distance.z) * 100000);
            view.RPC("loselife", PhotonTargets.All, view.viewID);
        }
    }
    [PunRPC]
    void loselife(int id)
    {
       
        if (id == view.viewID)
        {
            Debug.Log("TOUCHEE");
            life -= 10;
            if (life <= 0)
            {
                if(view.isMine)
                {
                    Application.LoadLevel("deathscreen");
                }
                Destroy(this.gameObject);
            }
        }
    }

}