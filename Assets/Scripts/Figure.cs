using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Figure : MonoBehaviour
{
    private enum Direction {
        Left,
        Right,
        Up,
        Down
    }
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) Shift(Direction.Left);
        if (Input.GetKeyDown(KeyCode.D)) Shift(Direction.Right);
        if (Input.GetKeyDown(KeyCode.W)) Shift(Direction.Up);
        if (Input.GetKeyDown(KeyCode.S)) Shift(Direction.Down);
    }

    private void Shift(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        var posZ = currentPos.z;
        var posX = currentPos.x;
        
        if (direction == Direction.Left) {
            posZ -= 1;
            gameObject.transform.position = new Vector3(currentPos.x, currentPos.y, posZ);
        }
        if (direction == Direction.Right) {
            posZ += 1;
            gameObject.transform.position = new Vector3(currentPos.x, currentPos.y, posZ);
        }
        if (direction == Direction.Up) {
            posX -= 1;
            gameObject.transform.position = new Vector3(posX, currentPos.y, currentPos.z);
        }
        if (direction == Direction.Down) {
            posX += 1;
            gameObject.transform.position = new Vector3(posX, currentPos.y, currentPos.z);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Figure");
    }
}
