﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour
{
    //public delegate void ItemSelect(int Itemid);
    //public static event ItemSelect ItemSelected;
    public delegate void SlotSelect(int Slotid);
    public static event SlotSelect SlotSelected;


    public void Click()
    {
        //ItemSelected(GetComponent<EmptyItemSlot>().storedItemID);
        SlotSelected(GetComponent<EmptyItemSlot>().slotID);
    }

}
