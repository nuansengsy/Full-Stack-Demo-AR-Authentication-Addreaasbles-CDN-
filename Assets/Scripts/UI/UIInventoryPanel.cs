using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPanel : MonoBehaviour
{
    public GameObject emptySlot;
    public List<GameObject> slotsList;
    public int selectedSlotID;

    void OnEnable()
    {
        DelegateHandler.SlotSelected += UpdateSelectedSlotID;
    }

    void OnDisable()
    {
        DelegateHandler.SlotSelected -= UpdateSelectedSlotID;
    }

    public void UpdateSelectedSlotID(int id)
    {
        slotsList[selectedSlotID].GetComponent<EmptyItemSlot>().checkBox.SetActive(false);
        selectedSlotID = id;
        slotsList[selectedSlotID].GetComponent<EmptyItemSlot>().checkBox.SetActive(true);
    }
}
