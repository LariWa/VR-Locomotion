using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Player_Movement : MonoBehaviour
{

    public Transform Hmd;
    public SteamVR_Action_Vector2 MoveAction;
    public SteamVR_Input_Sources CybershoesSource;
    public SteamVR_Input_Sources ControllerSource;
    public float speedController;
    public float speedShoes;
    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;
    CharacterController character;
    float moveFB, moveLR;
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
        moveFB = MoveAction.GetAxis(ControllerSource).y * speedController;
        moveLR = MoveAction.GetAxis(ControllerSource).x * speedController;


        CheckForWaterHeight();
        Vector3 hmdDirectionForward = new Vector3(Hmd.forward.x, 0, Hmd.forward.z);
        Vector3 hmdDirectionRight = new Vector3(Hmd.right.x, 0, Hmd.right.z);
        hmdDirectionForward = Vector3.Normalize(hmdDirectionForward);
        hmdDirectionRight = Vector3.Normalize(hmdDirectionRight);


        Vector3 movement = (hmdDirectionForward * moveFB + hmdDirectionRight * moveLR) + new Vector3(0f, gravity, 0f);

        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

        //Shoes
        moveFB = MoveAction.GetAxis(CybershoesSource).y * speedShoes;
        moveLR = MoveAction.GetAxis(CybershoesSource).x * speedShoes;


        movement = (hmdDirectionForward * moveFB + hmdDirectionRight * moveLR) + new Vector3(0f, gravity, 0f);
         movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

    }
 
 


}
