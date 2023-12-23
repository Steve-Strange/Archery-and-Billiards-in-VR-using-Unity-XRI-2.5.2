using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Doorknob : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionReference RightGripActionReference;
    public InputActionReference LeftGrabActionReference;
    public InputActionReference RightHandPositionReference;
    public InputActionReference LeftHandPositionReference;
    GameObject grabHand;

    bool GrabStatus = false;
    Vector3 RightHandPosition;
    Vector3 LeftHandPosition;

    Vector3 originalPosition;


    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // float RightGripButtonStatus = RightGripActionReference.action.ReadValue<float>();
        // float LeftGripButtonStatus = RightGripActionReference.action.ReadValue<float>();
        // RightHandPosition = RightHandPositionReference.action.ReadValue<Vector3>();
        // LeftHandPosition = LeftHandPositionReference.action.ReadValue<Vector3>();
        // if(GrabStatus == true){
        //     Debug.Log(grabHand.name);
        //     if(grabHand.name == "Right Controller" && RightGripButtonStatus > 0.9f){
        //         gameObject.transform.localRotation = Quaternion.LookRotation(gameObject.transform.position - RightHandPosition);
        //     }
        //     else if(grabHand.name == "Left Controller" && LeftGripButtonStatus > 0.9f){
        //         gameObject.transform.localRotation = Quaternion.LookRotation(gameObject.transform.position - LeftHandPosition, Vector3.left);
        //     }
        // }
        
    }

    public void GrabDoorKnob(){
        float RightGripButtonStatus = RightGripActionReference.action.ReadValue<float>();
        float LeftGripButtonStatus = RightGripActionReference.action.ReadValue<float>();
        RightHandPosition = RightHandPositionReference.action.ReadValue<Vector3>();
        LeftHandPosition = LeftHandPositionReference.action.ReadValue<Vector3>();
        transform.localPosition = originalPosition;
        if(RightGripButtonStatus > 0.9f){
            gameObject.transform.localRotation = Quaternion.LookRotation(gameObject.transform.position - RightHandPosition);
        }
        else if(LeftGripButtonStatus > 0.9f){
            gameObject.transform.localRotation = Quaternion.LookRotation(gameObject.transform.position - LeftHandPosition);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "XRController"){
            GrabStatus = true;
            Debug.Log("Hand is on the doorknob");
            grabHand = other.gameObject;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "XRController"){
            GrabStatus = false;
            Debug.Log("Hand is off the doorknob");
            grabHand = null;
        }
    }


}

