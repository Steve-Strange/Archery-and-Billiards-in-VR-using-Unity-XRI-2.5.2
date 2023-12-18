using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class GrabToGet : MonoBehaviour
{
    public GameObject arrowPrefab; // Assign your arrow prefab with XR Grab Interactable component

    public GameObject rightHand;
    public GameObject leftHand;

    public InputActionReference RightGripActionReference;
    public InputActionReference LeftGripActionReference;

    GameObject handInTrigger;

    void Start()
    {

        rightHand = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Right Controller");
        leftHand = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Left Controller");
    }

    void Update()
    {
        
    }

    public void GenerateArrow()
    {
        Debug.Log("handInTrigger: " + handInTrigger);
        float rightGripValue = RightGripActionReference.action.ReadValue<float>();
        float leftGripValue = LeftGripActionReference.action.ReadValue<float>();

        if(rightGripValue > 0.9)
        {
            handInTrigger = rightHand;
        }
        else if(leftGripValue > 0.9)
        {
            handInTrigger = leftHand;
        }
        else
        {
            handInTrigger = null;
        }

        var arrowInstance = Instantiate(arrowPrefab, handInTrigger.GetComponent<Transform>().position, handInTrigger.GetComponent<Transform>().rotation);

    }

}
