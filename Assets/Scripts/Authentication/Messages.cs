using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public Text meassage;
    // Start is called before the first frame update

    public void ShowMessage(string text)
    {
        meassage.text = text;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        meassage.text = "";
    }
}
