using UnityEngine;

public class InputService : MonoBehaviour
{
    private float directionX;
    private bool isLeftAltPressed = false;

    public float getDirectionX()
    {
        directionX = 0;

        if (Input.GetKey(KeyCode.D))
        {
            directionX = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionX = -1;
        }

        return directionX;
    }

    public bool getLeftAltPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isLeftAltPressed = !isLeftAltPressed;
        }
        return isLeftAltPressed;
    }

    public bool getSpacePressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }

    public bool getMouseLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
}
