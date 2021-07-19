using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchMovement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveTouch playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveTouch>();
    }

    public void OnPointerUp(PointerEventData data)
    {
        playerMove.StopMoving();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
        {
            playerMove.SetMoveLeft(true);
        }
        else
        {
            playerMove.SetMoveLeft(false);
        }
    }
}
