using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInputTest : MonoBehaviour
{
    public InputActionReference LeftXButtonActionReference;
    public InputActionReference RightGripActionReference;
    public InputActionReference RightTriggerActionReference;
    public InputActionReference LeftHandAction;
    public InputActionReference RightHandAction;
    private GameObject cue;
    private GameObject touchPoint;

    private Vector3 cuePosition;
    float cueLength;
    private Vector3 touchPointPostion;
    private Vector3 grabPosition;
    float grabPositionLength;
    bool startHolding;
    
    void Start()
    {
        cue = GameObject.Find("Cue");
        cueLength = cue.transform.localScale.y;
        touchPoint = GameObject.Find("Cue/Trigger");
        
    }
    private void Update()
    {
        cuePosition = cue.transform.position;
        touchPointPostion = touchPoint.transform.position;
        GetGripValue();

    }
    private void GetGripValue()
    {
        Vector3 leftHandPosition = LeftHandAction.action.ReadValue<Vector3>();
        Vector3 rightHandPosition = RightHandAction.action.ReadValue<Vector3>();
        grabPosition = cue.GetComponent<GrabbedObjectName>().grabPosition;

        float XButtonStatus = LeftXButtonActionReference.action.ReadValue<float>();
        float RightGripButtonStatus = RightGripActionReference.action.ReadValue<float>();
        float RightTriggerButtonStatus = RightTriggerActionReference.action.ReadValue<float>(); 

        
        if(RightGripButtonStatus > 0.9f && cue.GetComponent<GrabbedObjectName>().cueGrabbed){
            startHolding = true;
        }

        if(RightGripButtonStatus < 0.9f){
            startHolding = false;
        }

        if(startHolding && XButtonStatus > 0.9f && RightTriggerButtonStatus < 0.1f){
            cue.GetComponent<Rigidbody>().useGravity = false;
            cue.transform.parent = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)").transform;
            AttachCueToHand(leftHandPosition, rightHandPosition);
        }
        else {
            cue.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    private void AttachCueToHand(Vector3 leftHandPosition, Vector3 rightHandPosition)
    {
        
        grabPositionLength = cue.GetComponent<GrabbedObjectName>().grabPositionLength;

        // 计算右手到左手的向量
        Vector3 cueDirection = leftHandPosition - rightHandPosition;
        cue.transform.localPosition = rightHandPosition + (grabPositionLength) * (cueDirection.normalized);
        cue.transform.localRotation = Quaternion.LookRotation(cueDirection, Vector3.forward);
    }

}