using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadyEncounter : MonoBehaviour
{

    public Sprite shadyEncounter;       //CHANGE NAME
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
        CompleteButton.onClick.AddListener(TaskonCLick);
        s = cam.GetComponent<NewBehaviourScript>();
        SpriteRenderer sr = ShowCard.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x == Player.transform.position.x && this.transform.position.z == Player.transform.position.z)
        {
            if (isDone && !stch)
            {
                s.canMove = true;
                stch = true;
            }
            else if (!isDone)                // INSERT EVENT HERE
            {
                Parchemin.gameObject.SetActive(true);
                sr.sprite = shadyEncounter;
                Recit.text = "A mysterious man challenges thee..";

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

    private void OnMouseEnter()
    {
        sr.sprite = shadyEncounter;
    }
    private void OnMouseExit()
    {
        sr.sprite = null;
    }

    private void TaskonCLick()
    {
        if (this.transform.position.x == Player.transform.position.x && this.transform.position.z == Player.transform.position.z)
        {
            isDone = true;
            CompleteButton.enabled = false;
        }
    }
}
