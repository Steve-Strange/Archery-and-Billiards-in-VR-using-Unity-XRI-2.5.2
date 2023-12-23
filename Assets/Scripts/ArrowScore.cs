using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetCenter;
    void Start()
    {
        targetCenter = GameObject.Find("Target/Center");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "Arrow"){
            float distance = 10 - (new Vector3(0, collider.transform.position.y, collider.transform.position.z) - new Vector3(0, targetCenter.transform.position.y, targetCenter.transform.position.z)).magnitude * 10;
            
            if(distance < 0){
                gameObject.GetComponentInChildren<Text>().text = "Miss";
            }
            else {
                gameObject.GetComponentInChildren<Text>().text = Mathf.CeilToInt(distance).ToString();
            }
            
            collider.tag = "ArrowOn";
        }
    }
}
