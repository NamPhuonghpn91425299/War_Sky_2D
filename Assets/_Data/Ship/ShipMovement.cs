using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.Moving();
        this.LookAtTarget();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = targetPosition - transform.parent.position;
        diff.Normalize();

        //hàm Atan2 sẽ trả về một góc giữa 2 trục bằng đơn vị radian
        //nhân với Rad2Deg để rot_z được trả về đơn vị độ
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; 
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }

}
