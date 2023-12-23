using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LightController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ControlOneLight(){
        if(gameObject.GetComponent<Light>().intensity == 0) {
            gameObject.GetComponent<Light>().intensity = 40000f;
        }
        else {
            gameObject.GetComponent<Light>().intensity = 0;
        }
    }

    public void Uninstall(){
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }  

    void OnTriggerEnter(Collider other){
        if(other.name == "BrokenLightBulb") {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Light>().intensity = 40000f;
            gameObject.transform.position = other.transform.position;
        }
    }
}
