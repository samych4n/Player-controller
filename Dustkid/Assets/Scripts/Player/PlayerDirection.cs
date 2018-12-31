using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    int playerDirectionX = -1;
    int playerDirectionY = 1;
    SpriteRenderer spriteRenderer;

    public int CurrentDirectionX { get { return playerDirectionX; } }
    public int CurrentDirectionY { get { return playerDirectionY; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPlayerDirectionX(float directionX)
    {
        if (directionX == 0) return;
        if(directionX > 0 && playerDirectionX != 1)
        {
            playerDirectionX = 1;
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = 0;
            transform.rotation = Quaternion.Euler(rotation);
        }
        else if (directionX < 0 && playerDirectionX != -1)
        {
            playerDirectionX = -1;
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = 180;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }

}
