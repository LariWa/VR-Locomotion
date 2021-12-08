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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() 
    { 
        //Get Input
        float forwardInput = MoveAction.GetAxis(CybershoesSource).y; 
        float sidewaysInput = MoveAction.GetAxis(CybershoesSource).x; 
        //Y is cancelled out here becuase we don't want any height values.
        Vector3 hmdDirectionForward = new Vector3(Hmd.forward.x, 0, Hmd.forward.z); 
        Vector3 hmdDirectionRight = new Vector3(Hmd.right.x, 0, Hmd.right.z); 
        hmdDirectionForward = Vector3.Normalize(hmdDirectionForward); 
        hmdDirectionRight = Vector3.Normalize(hmdDirectionRight); 
        //Calculate the new Velocity
        Vector3 vel = hmdDirectionForward * forwardInput + hmdDirectionRight * sidewaysInput; 
        vel *= Speed * Time.fixedDeltaTime; 
        //Apply the Velocity
        transform.position += vel; 
 } 

}
