using UnityEngine;

public class Background_Follow : MonoBehaviour
{

    public Transform cameraTransform; // �Դ������ͧ
    public float parallaxEffectMultiplier = 0.5f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        //����͹�����еԴ������ͧ
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplier, 0);
        lastCameraPosition = cameraTransform.position;
    }
}

