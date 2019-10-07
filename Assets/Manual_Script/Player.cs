using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject ViewHitBox, ViewModel, ViewCamera;
    public Vector3 HitboxPosition;
    public float Speed;
    
    public float Y_Current_Rotation = 0;

    Rigidbody rigidbody;
    Animator ViewModelanimator;

	// Use this for initialization
	void Start () {
        ViewModelanimator = ViewModel.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
	}

    Vector3 moveVelocity_xz;
    float X_Rotation, Y_Rotation;
    // Update is called once per frame
    void Update()
    {
        //Fire and Reload Anims
        if (Input.GetButtonDown("Fire1")) {
            ViewModelanimator.SetTrigger("Fire");
        }

        if (Input.GetButtonDown("Reload"))
        {
            ViewModelanimator.SetTrigger("Reload");
        }


        X_Rotation = 0; Y_Rotation = 0;
        if (!Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
            X_Rotation = Input.GetAxis("Mouse X");
            Y_Rotation = Input.GetAxis("Mouse Y");
            Y_Current_Rotation += Input.GetAxis("Mouse Y");
            ViewModel.transform.RotateAround(ViewCamera.transform.position, Vector3.up, X_Rotation);//Y axis movement
            if(Y_Current_Rotation <= 85f && Y_Current_Rotation >= -85f)
            { 
            ViewModel.transform.RotateAround(ViewCamera.transform.position, ViewModel.transform.right, -Y_Rotation);//X axis movement
            }
            Y_Current_Rotation = Mathf.Clamp(Y_Current_Rotation, -85f, 85f);
            moveVelocity_xz = new Vector3(ViewModel.transform.forward.x, 0f, ViewModel.transform.forward.z).normalized * Input.GetAxis("Vertical") 
                + new Vector3(ViewModel.transform.right.x, 0, ViewModel.transform.right.z).normalized * Input.GetAxis("Horizontal");
            rigidbody.velocity = moveVelocity_xz * Speed + new Vector3(0f,rigidbody.velocity.y,0f); //Velocity Activate to Camera Movements

            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.velocity = new Vector3(0, -Physics.gravity.y * 0.5f, 0);
            }
        }
        else {
            Cursor.lockState = CursorLockMode.None;
        }
        ViewHitBox.transform.eulerAngles = new Vector3(0f, ViewHitBox.transform.eulerAngles.y, 0f);
    }
}
