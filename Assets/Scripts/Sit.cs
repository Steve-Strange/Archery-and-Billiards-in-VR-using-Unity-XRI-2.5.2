using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Sit : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionReference LeftXButtonActionReference;

    Vector3 originalPosition;
    Quaternion originalRotation;
    GameObject person;
    bool sitStatus = false;
    void Start()
    {
        person = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)");
    }

    // Update is called once per frame
    void Update()
    {
        float LeftXButtonStatus = LeftXButtonActionReference.action.ReadValue<float>();

        if(sitStatus && LeftXButtonStatus > 0.9f){
            person.transform.position = originalPosition;
            person.transform.rotation = originalRotation;
            sitStatus = false;
            person.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            person.GetComponent<Rigidbody>().isKinematic = false;
        }

    }

    public void SitOn(){
        sitStatus = true;
        person.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        person.GetComponent<Rigidbody>().isKinematic = true;
        originalPosition = person.transform.position;
        originalRotation = person.transform.rotation;
        person.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        person.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 90, 0);
    }

}
