using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCard : MonoBehaviour
{

    public Sprite Image;       //CHANGE NAME


    //STAPLE

    public string name;
    public GameObject ShowCard;
    public GameObject cam;
    public SpriteRenderer sr;
    public GameObject Player;
    public Button CompleteButton;
    public Image Parchemin;
    public Text Recit;

    public bool isDone = false;
    public NewBehaviourScript s;
    private bool stch = false;

    // Use this for initialization
    void Start()
    {

        switch (name)
        { }
     //   CompleteButton.onClick.AddListener(TaskonCLick);
        s = cam.GetComponent<NewBehaviourScript>();
        SpriteRenderer sr = ShowCard.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x == Player.transform.position.x && this.transform.position.z == Player.transform.position.z)
        {
            if (isDone && !stch)
            {
                s.canMove = true;
                stch = true;
                Parchemin.gameObject.SetActive(false);
            }

            //STAPLE ENDS

            else if (!isDone)                // INSERT EVENT HERE
            {
                Parchemin.gameObject.SetActive(true);
                sr.sprite = Image;

                switch (name)
                {
                    case "ShadyEncounter":
                        Recit.text = "A mysterious man challenges thee..";
                        break;
                    case "TheGate":
                        Recit.text = "You see a large gate, which seems to be well guarded by sentinels \n Even though you don't really know whether the inhabitants  \n of the town beyond are hostile or not, you feel uncertain \n about revealing yourself already. \n What do you wish to do ?";
                        break;


                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    Parchemin.gameObject.SetActive(false);
                    isDone = true;
                }



            }

            }
        
        else
        {
            stch = false;
        }
    }

    //STAPLE


    private void OnMouseEnter()
    {
        sr.sprite = Image; // CHANEGE NAME
    }
    private void OnMouseExit()
    {
        sr.sprite = null;
    }


    //STAPLE ENDS

    private void TaskonCLick()
    {
        if (this.transform.position.x == Player.transform.position.x && this.transform.position.z == Player.transform.position.z)
        {
            isDone = true;
            CompleteButton.enabled = false;
        }
    }
}
