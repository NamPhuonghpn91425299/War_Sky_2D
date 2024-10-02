using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : NamMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 3f;
    private void FixedUpdate()
    {
        this.Following();
    }
    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
    //protected virtual void Following()
    //{
    //    if (this.target == null) return;

    //    Vector3 newPosition = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);

    //    // Tăng khoảng cách trên trục Z
    //    float zOffset = 5f; // Bạn có thể điều chỉnh giá trị này
    //    newPosition.z -= zOffset;

    //    transform.position = newPosition;
    //}
}
