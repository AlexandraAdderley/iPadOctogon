using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(requiredComponent: typeof(ARRaycastManager), requiredComponent2: typeof(ARPlaneManager))]
public class placeObject : MonoBehaviour
{

    private bool isPlaced = false;
    public GameObject prefab;
    private ARRaycastManager aRRaycastManager;

    private ARPlaneManager aRPlaneManager;

  //  private ARTrackableManager aRTrackableManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Material _planeMaterial;

    private void Awake(){
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();

   //     aRTrackableManager = GetComponent<ARTrackableManager>;
    }

    private void OnEnable(){
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable(){
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    public void EnableReposition(){
        isPlaced = false;

    }

    private void FingerDown(EnhancedTouch.Finger finger){
        if(finger.index !=0) return;


        if (!isPlaced){

            
            if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon)){
                foreach(ARRaycastHit hit in hits){


                    Pose pose = hit.pose;
        //          GameObject obj = Instantiate(prefab, pose.position, pose.rotation);



                    prefab.transform.position = pose.position;
                    prefab.transform.rotation = pose.rotation;
                    prefab.SetActive(true);
                    _planeMaterial.SetColor("_TexTintColor", new Color(1.0f, 1.0f, 1.0f, 0.0f));
           //         ARPlaneManager.
                    isPlaced = true;

            //        ARTrackableManager.SetTrackablesActive();

                }



            }
        }

    }

}
