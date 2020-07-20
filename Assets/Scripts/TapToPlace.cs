using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

[RequireComponent(typeof(ARRaycastManager))]

public class TapToPlace : MonoBehaviour
{

    [SerializeField] private GameObject placementIndicator;
    [SerializeField] private ARRaycastManager arRaycastManager;
    private bool placementIsPoseValid;
    //private Vector2 touchuPosition;
    private Pose placementPose;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;

    public GameObject placedObject;
    private bool objectPlaced;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();


        //if (Input.GetKeyDown(KeyCode.Mouse0) && CheckForUIElements())
        //{
        //    Debug.Log("Cliked");
        //    PlaceItem();
        //}

        if (placementIsPoseValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && CheckForUIElements())
        {
            PlaceItem();
        }


    }

    void OnEnable()
    {
        DelegateHandler.SlotSelected += DestroyPlacedObject;
    }

    void OnDisable()
    {
        DelegateHandler.SlotSelected -= DestroyPlacedObject;
    }

    public bool CheckForUIElements()
    {
        
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //m_PointerEventData.position = Input.mousePosition;
            m_PointerEventData.position = Input.GetTouch(0).position;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

            if (results.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
    }


    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        if (arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon))
        {
            placementIsPoseValid = true;
            placementPose = hits[0].pose;
        }
        else
        {
            placementIsPoseValid = false;
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementIsPoseValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void PlaceItem()
    {
        if(!objectPlaced)
        {
            placedObject = Instantiate(Inventory.SharedInstance.handle.Result, placementPose.position, placementPose.rotation, transform);
            //placedObject = Instantiate(Inventory.SharedInstance.handle.Result, new Vector3(0, 0, 1), Quaternion.identity, transform);
            objectPlaced = true;
        }
        else
        {
            placedObject.transform.position = placementPose.position;
            //placedObject.transform.position = new Vector3(0, 0, 1);
        }

    }

    public void DestroyPlacedObject(int id)
    {
        if(placedObject != null)
        {
            Destroy(placedObject);
            objectPlaced = false;
            //Debug.Log(id);
        }
    }
}
