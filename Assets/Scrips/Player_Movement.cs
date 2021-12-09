 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Player_Movement : MonoBehaviour
{

    public float Speed;
    public Transform Hmd;
    public SteamVR_Action_Vector2 MoveAction;
    public SteamVR_Input_Sources CybershoesSource;
    public float speed = 10.0f;
    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;
    CharacterController character;
    float moveFB, moveLR;
    float rotX, rotY;
    float gravity = -9.8f;
    public Transform cameraRig;
    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        if (Application.isEditor)
        {
            sensitivity = sensitivity * 1.5f;
        }
        //head = SteamVR_Render.Top().head;
        //cameraRig = SteamVR_Render.Top().origin;

    }
    void CheckForWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        moveFB = MoveAction.GetAxis(CybershoesSource).y * speed;
        moveLR = MoveAction.GetAxis(CybershoesSource).x * speed;

        //rotX = Input.GetAxis("Mouse X") * sensitivity;
        //rotY = Input.GetAxis("Mouse Y") * sensitivity;

        //rotX = Input.GetKey (KeyCode.Joystick1Button4);
        //rotY = Input.GetKey (KeyCode.Joystick1Button5);

        CheckForWaterHeight();
        Vector3 hmdDirectionForward = new Vector3(Hmd.forward.x, 0, Hmd.forward.z);
       Vector3 hmdDirectionRight = new Vector3(Hmd.right.x, 0, Hmd.right.z);
        hmdDirectionForward = Vector3.Normalize(hmdDirectionForward);
        hmdDirectionRight = Vector3.Normalize(hmdDirectionRight);
        //   CameraRotation(cam, rotX, rotY);
        // HandleHead();
        // transform.rotation = Hmd.rotation;
       // HandleHead();
      //  Vector3 movement = new Vector3(hmdDirectionForward*moveFB, gravity, moveLR);


        Vector3 movement = (hmdDirectionForward * moveFB + hmdDirectionRight * moveLR)+new Vector3 (0f,gravity, 0f);



        //CameraRotation(hmd, rotX, rotY);


        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

    }
    void HandleHead()
    {
        Vector3 oldPos = Hmd.position;
        Quaternion oldRot = Hmd.rotation;

        transform.eulerAngles = new Vector3(0.0f, Hmd.eulerAngles.y, 0.0f);
        Hmd.position = oldPos;
        Hmd.rotation = oldRot;
            }
    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
    }
    void FixedUpdate() 
    { 
        ////Get Input
        //float forwardInput = MoveAction.GetAxis(CybershoesSource).y; 
        //float sidewaysInput = MoveAction.GetAxis(CybershoesSource).x; 
        ////Y is cancelled out here becuase we don't want any height values.
        //Vector3 hmdDirectionForward = new Vector3(Hmd.forward.x, 0, Hmd.forward.z); 
        //Vector3 hmdDirectionRight = new Vector3(Hmd.right.x, 0, Hmd.right.z); 
        //hmdDirectionForward = Vector3.Normalize(hmdDirectionForward); 
        //hmdDirectionRight = Vector3.Normalize(hmdDirectionRight); 
        ////Calculate the new Velocity
        //Vector3 vel = hmdDirectionForward * forwardInput + hmdDirectionRight * sidewaysInput; 
        //vel *= Speed * Time.fixedDeltaTime; 
        ////Apply the Velocity
        //transform.position += vel; 
 } 

}
