
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;
    public Camera playerCamera;
    public CharacterController characterController;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    public Vector3 moveDirection = Vector3.zero;
    public float rotationX = 0;

    public bool canMove = true;
    public LayerMask floor;
    public EventReference footStepsEvent;
    public EventInstance footStepsSound;
    public EventReference jumpEvent;
    public EventInstance jumpSound;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
