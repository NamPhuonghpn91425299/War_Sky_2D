using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance;}

    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    // Start is called before the first frame update
    void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Chỉ được dùng 1 singleton");
        InputManager.instance = this;
    }
     void Update()
    {
        this.GetMouseDown();
    }
    void FixedUpdate()
    {
        this.GetMouse();
    }
    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetMouse()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
