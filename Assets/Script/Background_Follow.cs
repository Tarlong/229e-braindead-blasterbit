using UnityEngine;

public class Background_Follow : MonoBehaviour
{

    public Transform cameraTransform; // ติดตามกล้อง
    public float parallaxEffectMultiplier = 0.5f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        //เคลื่อนที่และติดตามกล้อง
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplier, 0);
        lastCameraPosition = cameraTransform.position;
    }
}

