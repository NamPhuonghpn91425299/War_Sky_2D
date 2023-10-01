using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public int moveSpeed = 10;
    public Vector3 direction= Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
