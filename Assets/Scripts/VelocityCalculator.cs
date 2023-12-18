using UnityEngine;

public class VelocityCalculator : MonoBehaviour
{
    private Vector3 previousPosition;
    public Vector3 speed;

    void Start()
    {
        
    }

    void Update()
    {
        // 获取当前帧的位置
        Vector3 currentPosition = transform.position;

        Vector3 displacement = currentPosition - previousPosition;

        // 计算速度（位移除以时间）
        speed = displacement / Time.deltaTime;

        // 更新前一帧的位置
        previousPosition = currentPosition;

    }

}
