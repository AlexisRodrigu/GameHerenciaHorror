using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    
    CharacterController characterController;
    public float walkSpeed = 10.0f;
    public float runSpeed = 20.0f;
    public float gravity = 30.0f;
    public float jumpSpeed = 10.0f;
    private Vector3 move = Vector3.zero;

    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 3.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;

    public float minRotationY = -90.0f;
    public float maxRotationY = 100.0f;
    float h_mouse, v_mouse;


    public GameObject[] gun = new GameObject [2];
    //public GameObject gun;
    public GameObject item;

    public static bool interactuar;
   public bool fire;
  
   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        item = GameObject.FindGameObjectWithTag("Item");
    }
    void Update()
    {
        MovementPlayer();
        Comprobando();
    }
    void Comprobando()
    {
        if (item == null)
        {
            for (int i = 0; i < 2; i++)
            {
                gun[i].SetActive(true);
            }

            Destroy(item);
        }
    }
    void MovementPlayer()
    {
        interactuar = Input.GetButtonDown("Interactuar");
        fire = Input.GetButtonDown("Fire1");


        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);
        transform.Rotate(0, h_mouse, 0);

        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (Input.GetKey(KeyCode.LeftAlt))
                move = transform.TransformDirection(move) * runSpeed;

            else
                move = transform.TransformDirection(move) * walkSpeed;

            if (Input.GetKey(KeyCode.Space))
                move.y = jumpSpeed;
        }
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
