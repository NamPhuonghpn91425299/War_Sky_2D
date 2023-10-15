using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : NamMonoBehaviour
{
    public float moveSpeed = 1;
    public Vector3 direction = Vector3.right;

    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
