using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GoBack : MonoBehaviour
{

    public void BackToLoginScene()
    {
        if (Inventory.SharedInstance.handle.IsValid())
        {
            Addressables.Release(Inventory.SharedInstance.handle);
        }
        SceneManager.LoadScene("Authentication");
    }
}
