using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbedObjectName : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private GameObject cue;

    public bool cueGrabbed;
    public Vector3 grabPosition;

    public float grabPositionLength;
    Vector3 cuePosition;

    void Start()
    {
        // 获取 XRGrabInteractable 组件
        interactable = GetComponent<XRGrabInteractable>();
        cue = GameObject.Find("Cue");

        // 添加事件处理函数
        interactable.onSelectEntered.AddListener(OnGrabbed);
        interactable.onSelectExited.AddListener(OnReleased);
    }

    // 当物体被抓取时调用
    private void OnGrabbed(XRBaseInteractor interactor)
    {
        cuePosition = GameObject.Find("Cue").transform.position;
        string objectName = gameObject.name;
        cueGrabbed = true;
        grabPosition = interactor.transform.position;
        grabPositionLength = Vector3.Distance(grabPosition, cuePosition);
    }

    // 当物体被释放时调用
    private void OnReleased(XRBaseInteractor interactor)
    {
        string objectName = gameObject.name;
        Debug.Log("Released: " + objectName);
    }
}
