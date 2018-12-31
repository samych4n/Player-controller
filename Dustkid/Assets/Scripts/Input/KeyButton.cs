using UnityEngine;
public struct KeyButton
{
    private KeyCode keyCode;
    private string buttonName;

    public bool IsPress { private set; get; }
    public bool IsPressDown { private set; get; }
    public bool IsPressUp { private set; get; }

    public KeyButton(KeyCode keyCode, string buttonName)
    {
        this.keyCode = keyCode;
        this.buttonName = buttonName;
        IsPress = false;
        IsPressDown = false;
        IsPressUp = false;
    }

    public void SetNewButton(KeyCode keyCode)
    {
        this.keyCode = keyCode;
    }
    public void SetNewButton(string buttonName)
    {
        this.buttonName = buttonName;
    }

    public void UpdateButtonState()
    {
        IsPressDown = Input.GetKeyDown(keyCode) || Input.GetButtonDown(buttonName);
        IsPress = Input.GetKey(keyCode) || Input.GetButton(buttonName);
        IsPressUp = Input.GetKeyUp(keyCode) || Input.GetButtonUp(buttonName);
    }

}
