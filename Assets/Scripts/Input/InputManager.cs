using System;
using UnityEngine.InputSystem;

public class InputManager
{
    private PlayerControls playerControls;

    public float Movement => playerControls.Gameplay.Movement.ReadValue<float>();

    //evento ação de jump
    public event Action OnJump;
    
    public InputManager()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.Enable();

        //jump
        playerControls.Gameplay.Jump.performed += OnJumpPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

}
