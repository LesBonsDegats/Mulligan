using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : MonoBehaviour {

    public Text Titre;
    public Text Recit;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    public Text B1text;
    public Text B2text;
    public Text B3text;
    public Text B4text;

    private bool clicked;

    private bool a = false;
    private bool b = false;
    private bool c = false;
    private bool d = false;

    public DialogueWindow(string titre, string recit, string b1text, string b2text, string b3text, string b4text, Func<bool> outcome1, Func<bool> outcome2, Func<bool> outcome3, Func<bool> Outcome4)
    {


    }

   // public int operate (Func<int, int, int> fon, int b, int a) { return fon(a, b); }

    // Use this for initialization
    void Start() {

        Button1.onClick.AddListener(PressButton1);
        Button2.onClick.AddListener(PressButton2);
        Button3.onClick.AddListener(PressButton3);
        Button4.onClick.AddListener(PressButton4);

    }

    // Update is called once per frame
    void Update() {
        clicked = false;
        StartCoroutine(WaitForClick());
    }



    IEnumerator WaitForClick()
    {
        while (true)
        {

            //  this.transform.position += new Vector3(1, 0, 1);
            if (clicked)
            {
                Dial();
                StopAllCoroutines();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public bool Dial()
    {

        if (a) //try to get a little closer
        {
            Recit.text = "Wow";
        }
        else if (b) //Come into the light and hail the city watch
        {
            Recit.text = "Wuuu";
        }
        else if (c) //Stay hidden for a moment
        {

        }
        else if (d) //Continue your journey
        {

        }

        return true;

    }


    private void PressButton1()
    {
            a = true;
            clicked = true;
        
    }
    private void PressButton2()
    {
            b = true;
            clicked = true;
  
    }
    private void PressButton3()
    {

            c = true;
            clicked = true;
        
    }
    private void PressButton4()
    {
     
            d = true;
            clicked = true;
        
    }


}

