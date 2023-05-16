using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float speed;
    private float minX;
    private float maxX;
    public Camera mainCam;

    private MoveDirection curMove;

    private void OnEnable()
    {
        speed = 1.5f;
        mainCam = FindObjectOfType<Camera>();
        SetColider();
        curMove = MoveDirection.moveLeft;
    }
  
    private void  SetColider()
    {
        maxX = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        minX = -mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    private void Update()
    {
        ChangeDirectionMove();
    }
    private void ChangeDirectionMove()
    {
        switch (curMove)
        {
            case MoveDirection.moveLeft:
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                transform.localScale = new Vector3(1, 1, 1);
                if (transform.position.x < minX)
                {  
                    curMove = MoveDirection.moveRight;
                }
                    break;
            case MoveDirection.moveRight:
                transform.Translate(-Vector3.left * Time.deltaTime * speed);
                transform.localScale = new Vector3(-1, 1, 1);
                if (transform.position.x > maxX)
                {
                    curMove = MoveDirection.moveLeft;
                }
                break;
            default:
                break;
        }
    }

    private enum MoveDirection
    {
        moveLeft, moveRight
    }

    

    
}
