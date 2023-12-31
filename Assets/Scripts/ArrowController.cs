using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject arrowPrefab;
    public GameObject arrowPlace;
    public GameObject arrowTrigger;
    public GameObject arrowBack;
    public Vector3 arrowHeading;

    public bool waitingToShoot = false;
    void Start()
    {
        arrowPlace = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Main Camera/ArrowPlace");
        arrowTrigger = GameObject.Find("Bow/ArrowTrigger");
        arrowBack = GameObject.Find("Bow/String/Notch");
    }

    // Update is called once per frame
    void Update()
    {
        arrowHeading = arrowTrigger.transform.position - arrowBack.transform.position;
        if (waitingToShoot) {
            gameObject.transform.position = arrowBack.transform.position + gameObject.transform.localScale.y/2.4f * arrowHeading.normalized;
            gameObject.transform.rotation = Quaternion.LookRotation(arrowHeading, Vector3.forward);
        }
    }

    
    public void GrabArrow(){

        GameObject arrow = Instantiate(arrowPrefab, arrowPlace.transform.position, arrowPlace.transform.rotation);
        arrow.transform.parent = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Main Camera").transform;
    }

    public void ReleaseArrow(){
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;
        if(arrowTrigger.GetComponent<ArrowTrigger>().arrowOnBow == gameObject) {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.transform.parent = arrowTrigger.transform;
            waitingToShoot = true;
        }

        Debug.Log("ReleaseArrow:" + gameObject.transform.parent);
    }

        void OnTriggerEnter(Collider other){
        if(other.tag == "Target"){
            gameObject.transform.parent = other.transform;
            gameObject.GetComponentInParent<Rigidbody>().velocity = new Vector3(0,0,0);
            gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
            gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
        
        }
        
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Target"){
            gameObject.transform.parent = null;
            gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
            gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        
        }
        
    }
}
