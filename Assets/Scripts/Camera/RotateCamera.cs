using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    

    private InputAction rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = InputSystem.actions.FindAction("Rotate");
    }

    // Update is called once per frame
    void Update()
    {
        float rotateValue = rotate.ReadValue<float>();
        transform.rotation *= Quaternion.Euler(0, rotateValue, 0);
    }
}
