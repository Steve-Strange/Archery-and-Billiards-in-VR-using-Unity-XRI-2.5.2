using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject slide1;
    public GameObject slide2;
    public bool doorOpen = false;
    private Vector3 slide1OrigianlPosition;
    private Vector3 slide2OrigianlPosition;
    float time;
    float duration = 2.0f;
    bool openStatus;

    void Start()
    {
        slide1 = GameObject.Find(gameObject.name + "/Slide1");
        slide2 = GameObject.Find(gameObject.name + "/Slide2");
        slide1OrigianlPosition = slide1.transform.localPosition;
        slide2OrigianlPosition = slide2.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if(openStatus){
            if (time < duration)
            {
                float t = time / duration;
                t = t * t * (3f - 2f * t);
                slide1.transform.localPosition = Vector3.Lerp(slide1OrigianlPosition, slide1OrigianlPosition + new Vector3(-0.8f, 0, 0), t);
                slide2.transform.localPosition = Vector3.Lerp(slide2OrigianlPosition, slide2OrigianlPosition + new Vector3(0.8f, 0, 0), t);
                time += Time.deltaTime;
            }
        }
        else{
            if (time > 0)
            {
                float t = time / duration;
                t = t * t * (3f - 2f * t);
                slide1.transform.localPosition = Vector3.Lerp(slide1OrigianlPosition, slide1OrigianlPosition + new Vector3(-0.8f, 0, 0), t);
                slide2.transform.localPosition = Vector3.Lerp(slide2OrigianlPosition, slide2OrigianlPosition + new Vector3(0.8f, 0, 0), t);
                time -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Person"){
            openStatus = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Person"){
            openStatus = false;
        }
    }

}
