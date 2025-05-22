using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJumpState : State
{
    private float _timer;

    public PlayerJumpState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        PlayerManager.instance.moveDirection.y = PlayerManager.instance.jumpPower;
        PlayerManager.instance.jumpSound.start();
    }

    public override void Update()
    {
        if (!PlayerManager.instance.characterController.isGrounded)
        {
            PlayerManager.instance.moveDirection.y -= PlayerManager.instance.gravity * Time.deltaTime;
        }
        if (_timer < 0.2f)
        {
            _timer += Time.deltaTime;

            return;
        }
        if (PlayerManager.instance.characterController.isGrounded)
        {
            PlayerManager.instance.jumpSound.start();
            Exit();
        }
        PlayerManager.instance.characterController.Move(PlayerManager.instance.moveDirection * Time.deltaTime);
    }

    public override void Exit()
    {
        _stateMachine.Begin(new PlayerGroundedState(_stateMachine));
    }
}
