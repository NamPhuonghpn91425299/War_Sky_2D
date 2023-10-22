using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    [SerializeField] protected float minCamPos = -10f;
    [SerializeField] protected float maxCamPos = 10f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;
        camPos.x = Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z = Random.Range(this.minCamPos , this.maxCamPos);


        Vector3 diff = camPos - objPos;
        diff.Normalize();
        //hàm Atan2 sẽ trả về một góc giữa 2 trục bằng đơn vị radian
        //nhân với Rad2Deg để rot_z được trả về đơn vị độ
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawLine(objPos, camPos, Color.red, Mathf.Infinity);
    }
}
