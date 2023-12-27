using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Running : MonoBehaviour
{

    public InputActionReference RightGripActionReference;
    public InputActionReference RightTriggerActionReference;
    public InputActionReference LeftGrabActionReference;
    public InputActionReference LeftTriggerActionReference;

    public GameObject Person;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject Head;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Right Controller");
        leftHand = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Left Controller");
        Person = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)");
        Head = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float RightGripButtonStatus = RightGripActionReference.action.ReadValue<float>();
        float RightTriggerButtonStatus = RightTriggerActionReference.action.ReadValue<float>();
        float LeftGrabButtonStatus = LeftGrabActionReference.action.ReadValue<float>();
        float LeftTriggerButtonStatus = LeftTriggerActionReference.action.ReadValue<float>();
        if(RightGripButtonStatus > 0.9f && RightTriggerButtonStatus > 0.9f && LeftGrabButtonStatus > 0.9f && LeftTriggerButtonStatus > 0.9f){
            Person.GetComponent<Rigidbody>().AddForce(speed * ((rightHand.GetComponent<VelocityCalculator>().speed.magnitude + leftHand.GetComponent<VelocityCalculator>().speed.magnitude)/1.8f) 
            * new Vector3(Head.transform.forward.x, 0, Head.transform.forward.z));
        }
        else if(RightGripButtonStatus > 0.9f && RightTriggerButtonStatus > 0.9f){
            Person.GetComponent<Rigidbody>().AddForce(speed * rightHand.GetComponent<VelocityCalculator>().speed.magnitude * new Vector3(Head.transform.forward.x, 0, Head.transform.forward.z));
        }
        else if(LeftGrabButtonStatus > 0.9f && LeftTriggerButtonStatus > 0.9f){
            Person.GetComponent<Rigidbody>().AddForce(speed * leftHand.GetComponent<VelocityCalculator>().speed.magnitude * new Vector3(Head.transform.forward.x, 0, Head.transform.forward.z));
        }
        
    }
}
