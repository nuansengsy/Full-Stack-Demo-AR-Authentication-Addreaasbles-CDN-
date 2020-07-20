using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using TMPro;

public class RemoteAssetsLoader : MonoBehaviour
{
    private List<IResourceLocation> remoteLocations;
    public AssetLabelReference label;
    public TextMeshProUGUI debug;

    public List<AssetReference> refList;
    public AsyncOperationHandle<GameObject> handle;
    private void Awake()
    {
        //Addressables.LoadResourceLocationsAsync(label.labelString).Completed += LocationLoaded;
    }

    //private void LocationLoaded(AsyncOperationHandle<IList<IResourceLocation>> obj)
    //{
    //    remoteLocations = new List<IResourceLocation>(obj.Result);
    //    debug.text = "loaded locations = " + remoteLocations.Count;
    //    foreach (var location in remoteLocations)
    //    {
    //        Addressables.LoadAsset<GameObject>(location).Completed += (handle) =>
    //        {
    //            Debug.Log(handle.Result);
    //            Inventory.SharedInstance.PutLoadedAssetToInventory(handle.Result);
    //        };

    //    }
    //}

    //private async void UploadRemoteAssets(string str)
    //{
    //    var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        

    //    foreach(var location in locations)
    //    {
    //        var obj = await Addressables.InstantiateAsync(location).Task;
    //        Inventory.SharedInstance.PutLoadedAssetToInventory(obj);
    //    }

    //}


}
