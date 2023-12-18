using UnityEngine;

public class CueController : MonoBehaviour
{
    private GameObject cue;
    private GameObject touchPoint;
    public GameObject rightHand;
    public GameObject leftHand;
    private float rotationMultiplier = 1f; // 根据实际需求调整

    void Start()
    {
        cue = GameObject.Find("Cue");
        rightHand = GameObject.Find("XR Interaction Setup/XR Origin (XR Rig)/Camera Offset/Right Controller");
        touchPoint = gameObject;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i <= 15; i++)
        {
            GameObject thisBall = GameObject.Find("Balls/Ball" + i);

            if (other.gameObject == thisBall)
            {
                // 计算出杆速度
                Vector3 handVelocity = rightHand.GetComponent<VelocityCalculator>().speed;

                // 计算力的大小 
                Vector3 force = handVelocity * 1f; // 根据具体需求调整倍数
                Debug.Log("force: " + force);

                // 施加力到当前球上，注意添加方向向量的计算
                Vector3 forceDirection = Vector3.Normalize(touchPoint.transform.position - cue.transform.position);
                Vector3 touchRadiusDirection = Vector3.Normalize(touchPoint.transform.position - thisBall.transform.position);

                Vector3 forceVector = Vector3.Dot(forceDirection, force) * forceDirection;

                Vector3 speedVector = Vector3.Dot(touchRadiusDirection, forceVector) * touchRadiusDirection;

                Vector3 rotationVector = forceVector - speedVector;


                thisBall.GetComponent<Rigidbody>().AddForce(speedVector, ForceMode.Impulse);

                // 根据碰撞具体位置给球一定的旋转
                Vector3 ballCenter = thisBall.transform.position;

                // 计算旋转轴
                Vector3 rotationAxis = Vector3.Cross(touchPoint.transform.position - ballCenter, touchPoint.transform.position - cue.transform.position);

                // 计算旋转速度，使用球的半径等因素进行调整
                float ballRadius = thisBall.GetComponent<SphereCollider>().radius;
                float rotationSpeed = rotationVector.magnitude * rotationMultiplier / ballRadius;

                // 施加旋转力到当前球上
                thisBall.GetComponent<Rigidbody>().AddTorque(rotationAxis * rotationSpeed, ForceMode.Impulse);

                Debug.Log("velocity:" + thisBall.GetComponent<Rigidbody>().velocity);
                Debug.Log("angularVelocity:" + thisBall.GetComponent<Rigidbody>().angularVelocity);

            }
        }
    }
}
