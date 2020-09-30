using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    float sightAngle;
    float angularSpeed;
    CharacterController cController;
    float rotationY,rotationX;
    // Start is called before the first frame update
    void Start()
    {
        cController = GetComponent<CharacterController>();
        sightAngle = 0f;
        angularSpeed = 0.001f;
        rotationY = 0;
        rotationX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if we want  rotation only around Y axis then we can use transform.Rotate(.....)
        // but if we want to add rotation around X-axis we need to use transform.localEulerAngles

        //      sightAngle+= angularSpeed*Input.GetAxis("Mouse X")*Time.deltaTime;
        //        transform.Rotate(new Vector3(0,sightAngle,0)); // sets up the sight direction of Player

        rotationX -= Input.GetAxis("Mouse Y") ;
        rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") ;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        if (Input.GetButton("Vertical")) // forward/backward
        {
            float speed = 0f;
            if (Input.GetKey(KeyCode.W)) // forward
                speed = 5f;
            else // backward
                speed = -5;
            
            // compute the direction "Forward" of player
            Vector3 dir = transform.forward * speed * Time.deltaTime;
            dir.y = 0; // if we want to stay on constant height then we simply zero the y-component of dir
            //dir = transform.TransformDirection(dir);

            cController.Move(dir);
        }
    }
}
