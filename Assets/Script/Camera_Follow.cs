using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera_Follw : MonoBehaviour
{
    public Transform player;    // ตัวละคร
    public Vector3 offset;      // ระยะห่างกล้องกับตัวละคร
    public float smoothSpeed = 0.125f;
    public float fixedY = 0f;    // ทำให้แกน Y ไม่ขยับ



    private void LateUpdate()
    {
        if (player == null) return;
        
        //ให้ขยับเฉพาะแกน X เท่านั้น
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, fixedY + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
