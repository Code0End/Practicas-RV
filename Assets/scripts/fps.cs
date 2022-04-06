using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    public float sensX;
    public float sensY;
    public float speed = 0.0f;

    float xRotation;
    float yRotation;

    public bool movi = true;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = gameObject.GetComponent<Rigidbody>();
     
    }

  
    // Update is called once per frame
    void Update()
    {
        mirar();
        if (movi == true)
            moverp();
        else
        {
            movera(); 
        }
    }

    void mirar()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);

    }

    void moverp()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }

    public void cb()
    {
        movi = false;
    }

    public void ca()
    {
        movi = true;
    }

    void movera()
    {
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);
        rb.velocity = forward * speed; 
    }


}
