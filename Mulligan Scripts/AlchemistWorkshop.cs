using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemistWorkshop : MonoBehaviour
{

    public Sprite AlchWorkshop;
    public GameObject ShowCard;
    public SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        SpriteRenderer sr = ShowCard.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        sr.sprite = AlchWorkshop;
    }
    private void OnMouseExit()
    {
        sr.sprite = null;
    }
}
