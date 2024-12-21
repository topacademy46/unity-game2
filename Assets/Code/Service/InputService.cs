using UnityEngine;

public class InputService : MonoBehaviour
{
    private float directionX;

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
}
