using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    // Start is called before the first frame update
    public float arrowSpeed = 300;
    public GameObject arrowTrigger;
    public GameObject arrowAttachedPoint;
    public GameObject arrowStartPoint;
    public GameObject stringStartPoint;
    public GameObject stringEndPoint;
    public GameObject stringMiddlePoint;
    void Start()
    {
        arrowTrigger = GameObject.Find("Bow/ArrowTrigger");
        arrowAttachedPoint = GameObject.Find("Bow/ArrowTrigger");
        stringStartPoint = GameObject.Find("Bow/String/Start");
        stringEndPoint = GameObject.Find("Bow/String/End");
        stringMiddlePoint = GameObject.Find("Bow/String/Notch");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReleaseString(){
        Debug.Log("ReleaseString");
        stringMiddlePoint.transform.position = (stringStartPoint.transform.position + stringEndPoint.transform.position + new Vector3(0, 0.07f, 0))/2;
        stringMiddlePoint.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        stringMiddlePoint.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        if(arrowTrigger.GetComponent<ArrowTrigger>().arrowOnBow){
            GameObject arrowOnBow = arrowTrigger.GetComponent<ArrowTrigger>().arrowOnBow;
            arrowOnBow.transform.parent = null;
            arrowOnBow.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            arrowOnBow.GetComponent<Rigidbody>().useGravity = true;
            arrowOnBow.GetComponent<ArrowController>().waitingToShoot = false;
            arrowOnBow.GetComponent<Rigidbody>().AddForce(arrowOnBow.GetComponent<ArrowController>().arrowHeading * arrowOnBow.GetComponent<ArrowController>().arrowHeading.magnitude * arrowSpeed);
        }
    }

}
