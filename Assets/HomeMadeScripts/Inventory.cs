using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject cam;
    public NewBehaviourScript s;

    public InventaireSlot Inventory1;
    public InventaireSlot Inventory2;
    public InventaireSlot Inventory3;
    public InventaireSlot Inventory4;
    public InventaireSlot Inventory5;
    public InventaireSlot Inventory6;
    public InventaireSlot Inventory7;
    public InventaireSlot Inventory8;
    public InventaireSlot Inventory9;

    public InventaireSlot InventoryHelmet;
    public InventaireSlot InventoryLeftHand;
    public InventaireSlot InventoryChest;
    public InventaireSlot InventoryRightHand;
    public InventaireSlot InventoryGreaves;

    public InventaireSlot InventoryTalisman1;
    public InventaireSlot InventoryTalisman2;
    public InventaireSlot InventoryTalisman3;

    private List<InventaireSlot> stashSlots = new List<InventaireSlot>();

    private List<InventaireSlot> equipSlots = new List<InventaireSlot>();

    public bool holding = false;
    public int holdid = 0;
    public InventaireSlot chosen;

    // Use this for initialization
    void Start()
    {
        chosen = Inventory1;
        s = cam.GetComponent<NewBehaviourScript>();

        stashSlots = new List<InventaireSlot>
        {
            Inventory1,    Inventory2,    Inventory3,
            Inventory4,    Inventory5,    Inventory6,
            Inventory7,    Inventory8,    Inventory9,
        };

        equipSlots = new List<InventaireSlot>()
        {
            InventoryHelmet,     InventoryLeftHand,   InventoryChest,
            InventoryRightHand,  InventoryGreaves,    InventoryTalisman1,
            InventoryTalisman2,  InventoryTalisman3
        };

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clicked(RaycastHit hit)
    {

            int prefixe = 0;
            prefixe = int.Parse(hit.transform.tag.Substring(9, hit.transform.tag.Length - 9));



            switch (prefixe)
            {
                case 1:

                    chosen = Inventory1;

                    break;
                case 2:
                    chosen = Inventory2;

                    break;
                case 3:
                    chosen = Inventory3;
                    break;

                case 4:
                    chosen = Inventory4;
                    break;

                case 5:
                    chosen = Inventory5;
                    break;

                case 6:
                    chosen = Inventory6;
                    break;
                case 7:
                    chosen = Inventory7;
                    break;
                case 8:
                    chosen = Inventory8;
                    break;
                case 9:
                    chosen = Inventory9;
                    break;
                case 10:
                    chosen = InventoryHelmet;
                    break;
                case 11:
                    chosen = InventoryLeftHand;
                    break;
                case 12:
                    chosen = InventoryChest;
                    break;
                case 13:
                    chosen = InventoryRightHand;
                    break;
                case 14:
                    chosen = InventoryGreaves;
                    break;
                case 15:
                    chosen = InventoryTalisman1;
                    break;
                case 16:
                    chosen = InventoryTalisman2;
                    break;
                case 17:
                    chosen = InventoryTalisman3;
                    break;

            }




            if (chosen.id == 0)
            {

                // if (holdid / 100 < 1 && prefixe < 10)
                // {
                chosen.setId(holdid);
                holdid = 0;
                s.canMove = true;
                // }
            }
            else if (holdid == 0)
            {
                holdid = chosen.id;
                chosen.setId(0);
                s.canMove = false;
            }
        
        else if (holdid != 0)
        {
            chosen.setId(holdid);
            holdid = 0;
            s.canMove = true;
        }
    }



    public bool AddItem(int itemId)
    {

        chosen = null;
        foreach (InventaireSlot slot in stashSlots)
        {
            if (slot.id == 0)
            {
                chosen = slot;
                break;
            }

        }

        if (chosen == null)
        {
            return false;
        }
        else
        {
            chosen.setId(itemId);
            return true;
        }
    }
}


