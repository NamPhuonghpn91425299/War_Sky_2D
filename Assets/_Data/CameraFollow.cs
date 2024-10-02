using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Con tàu cần follow
    public float smoothSpeed = 0.125f; // Tốc độ làm mịn chuyển động
    public Vector3 offset; // Offset của camera so với tàu

    void LateUpdate()
    {
        if (target == null) return;

        // Tính toán vị trí mong muốn của camera
        Vector3 desiredPosition = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            transform.position.z // Giữ nguyên vị trí z của camera
        );

        // Sử dụng Lerp để làm mịn chuyển động của camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Cập nhật vị trí của camera
        transform.position = smoothedPosition;
    }
}