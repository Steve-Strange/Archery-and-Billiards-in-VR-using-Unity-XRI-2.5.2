using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject arrowOnBow;
    public bool arrowStatus;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Arrow"){
            arrowStatus = true;
            arrowOnBow = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Arrow"){
            arrowStatus = false;
            arrowOnBow = null;
        }
    }
}
