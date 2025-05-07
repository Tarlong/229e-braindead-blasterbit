using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera_Follw : MonoBehaviour
{
    public Transform player;    // ����Ф�
    public Vector3 offset;      // ������ҧ���ͧ�Ѻ����Ф�
    public float smoothSpeed = 0.125f;
    public float fixedY = 0f;    // �����᡹ Y ����Ѻ



    private void LateUpdate()
    {
        if (player == null) return;
        
        //����Ѻ੾��᡹ X ��ҹ��
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, fixedY + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
