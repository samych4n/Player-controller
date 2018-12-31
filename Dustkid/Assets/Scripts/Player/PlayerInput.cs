using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    KeyButton dashButton = new KeyButton(KeyCode.X, "Fire2");
    KeyButton jumpButton = new KeyButton(KeyCode.Z, "Jump");
    KeyButton weakAttackButton = new KeyButton(KeyCode.RightControl, "Fire1");
    KeyButton heavyAttackButton = new KeyButton(KeyCode.C, "Fire3");
    float horizontal;
    float vertical;

    public KeyButton DashButton => dashButton;
    public KeyButton JumpButton => jumpButton;
    public KeyButton WeakAttackButton => weakAttackButton;
    public KeyButton HeavyAttackButton => heavyAttackButton;
    public float Horizontal => horizontal;
    public float Vertical => vertical;

    private void Update()
    {
        dashButton.UpdateButtonState();
        jumpButton.UpdateButtonState();
        weakAttackButton.UpdateButtonState();
        heavyAttackButton.UpdateButtonState();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
}

