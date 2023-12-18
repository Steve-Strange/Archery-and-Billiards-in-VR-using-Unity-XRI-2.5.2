using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public void ResetAll()
    {
        for (int i = 0; i <= 15; i++)
        {
            GameObject thisBall = GameObject.Find("Balls/Ball" + i);
            thisBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            thisBall.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            thisBall.transform.position = GameObject.Find("Balls/Ball" + i + " (1)").transform.position;

        }
    }

    public void ResetCue()
    {
        GameObject cue = GameObject.Find("Cue");
        cue.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        cue.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        cue.transform.position = GameObject.Find("Cue (1)").transform.position;
    }  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= 15; i++)
        {
            try
            {
                GameObject thisBall = GameObject.Find("Balls/Ball" + i);
                if (thisBall.transform.position.y < 0.6)
                {
                    thisBall.transform.position = GameObject.Find("Balls/ResetPoint" + i).transform.position;
                    thisBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    thisBall.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                }
            }
            catch
            {
                continue;
            }
        }
    }
}
