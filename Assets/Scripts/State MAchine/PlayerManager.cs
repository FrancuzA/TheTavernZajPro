
using FMOD.Studio;
using FMODUnity;
using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    public EventReference JumpSound;
    private EventInstance JumpSoundInstance;
    public EventReference WalkingSound;
    private EventInstance WalkingSoundInstance;

    public LayerMask Wood;
    public LayerMask Stone;



    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        WalkingSoundInstance = FMODUnity.RuntimeManager.CreateInstance(WalkingSound);
        JumpSoundInstance = FMODUnity.RuntimeManager.CreateInstance(JumpSound);
    }

    void Update()
    {

        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            StartCoroutine(Jumping());
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }

    public IEnumerator Jumping()
    {
        JumpSoundInstance.setParameterByName("isGrounded", 0);
        if (Physics.Raycast(Player.transform.position, Vector3.down, 1.1f, Wood))
        {
            JumpSoundInstance.setParameterByName("footSwitcher", 1);
            Debug.Log("switched to wood");
        }
        if (Physics.Raycast(Player.transform.position, Vector3.down, 1.1f, Stone))
        {
            JumpSoundInstance.setParameterByName("footSwitcher", 0);
            Debug.Log("switched to stone");
        }
        JumpSoundInstance.start();
        moveDirection.y = jumpPower;
        yield return new WaitUntil(() => !characterController.isGrounded);
        yield return new WaitUntil(() => characterController.isGrounded);
        Debug.Log("test");
        JumpSoundInstance.setParameterByName("isGrounded", 1);
        if (Physics.Raycast(Player.transform.position, Vector3.down, 1.1f, Wood))
        {
            JumpSoundInstance.setParameterByName("footSwitcher", 1);
            Debug.Log("switched to wood");
        }
        if (Physics.Raycast(Player.transform.position, Vector3.down, 1.1f, Stone))
        {
            JumpSoundInstance.setParameterByName("footSwitcher", 0);
            Debug.Log("switched to stone");
        }
        JumpSoundInstance.start();
    }
}

