using UnityEngine;

public class PlayerGroundedState : State
{
    private Transform transform;
    public PlayerGroundedState(StateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
        transform = _stateMachine.transform;
    }
    public override void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = PlayerManager.instance.canMove ? (isRunning ? PlayerManager.instance.runSpeed : PlayerManager.instance.walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = PlayerManager.instance.canMove ? (isRunning ? PlayerManager.instance.runSpeed : PlayerManager.instance.walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = PlayerManager.instance.moveDirection.y;
        PlayerManager.instance.moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetKeyDown(KeyCode.Space) && PlayerManager.instance.canMove && PlayerManager.instance.characterController.isGrounded)
        {
            _stateMachine.Begin(new PlayerJumpState(_stateMachine));
        }

        if (!PlayerManager.instance.characterController.isGrounded)
        {
            PlayerManager.instance.moveDirection.y -= PlayerManager.instance.gravity * Time.deltaTime;
        }

        PlayerManager.instance.characterController.Move(PlayerManager.instance.moveDirection * Time.deltaTime);
    }
}
