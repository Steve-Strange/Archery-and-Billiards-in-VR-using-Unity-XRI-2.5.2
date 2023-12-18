using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test: MonoBehaviour{
    public Transform sphere;

    void Update(){
        Vector3 dir = sphere.position - transform.position;  //正方体指向球体的向量dir = 球体坐标 - 正方体坐标
        Quaternion ang = Quaternion.LookRotation(dir, Vector3.up);  //创建一个 使正方体“看向”球体的旋转角
        transform.rotation = ang;

        Debug.DrawRay(transform.position, transform.up * 100, Color.blue);  //绘制正方体forward方向
        Debug.DrawRay(transform.position, transform.right * 100, Color.yellow);  //绘制正方体forward方向

        Debug.DrawRay(transform.position, dir, Color.green);  //绘制向量dir
        Debug.DrawRay(transform.position, ang.eulerAngles, Color.red);  //即：绘制正方体的旋转轴
    }
}