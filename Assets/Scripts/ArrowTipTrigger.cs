using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTipTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Target"){
            gameObject.
            gameObject.GetComponentInParent<Rigidbody>().velocity = new Vector3(0,0,0);
            gameObject.GetComponentInParent<Rigidbody>().useGravity = false;
            gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;
        
        }
        
    }

    
    void OnTriggerExit(Collider other){
        if(other.tag == "Target"){
            gameObject.GetComponentInParent<Rigidbody>().useGravity = true;
            gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        
        }
        
    }

}
