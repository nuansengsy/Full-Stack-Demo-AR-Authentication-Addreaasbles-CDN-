using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelSwith : MonoBehaviour
{
    public GameObject emailLoginPanel, guestLoginPanel, singUp_panel;

    public void ShowLoginPanel()
    {
        emailLoginPanel.SetActive(true);
        guestLoginPanel.SetActive(true);
        singUp_panel.SetActive(false);

    }

    public void ShowRegistrationPanel()
    {
        singUp_panel.SetActive(true);
        emailLoginPanel.SetActive(false);
        guestLoginPanel.SetActive(false);
    }
}
