using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using TMPro;

[System.Serializable]
public class Item
{
    public int index;
    public GameObject modelPrefab;
}

public class Inventory : MonoBehaviour
{
    public static Inventory SharedInstance;
    public List<AssetReference> refList;
    public AsyncOperationHandle<GameObject> handle;

    private void Awake()
    {
        if(SharedInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SharedInstance = this;
        }
    }

    void OnEnable()
    {
        DelegateHandler.SlotSelected += LoadAsset;
    }

    void OnDisable()
    {
        DelegateHandler.SlotSelected -= LoadAsset;
    }

    public void LoadAsset(int id)
    {
        if (handle.IsValid())
        {
            Addressables.Release(handle);
        }

        handle = refList[id].LoadAssetAsync<GameObject>();
    }

}
