using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float camX;
    public float camY;
    public Transform orientation;
    float xRot;
    float yRot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Allows player to use mouse to look around limiting it to +90 and -90 degrees vertically to avoid spinning
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * camX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * camY;

        yRot+=mouseX;
        xRot-=mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
