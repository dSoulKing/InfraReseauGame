using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private bool draggingItem = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;
    private Vector3 startPosition;
    private bool boolPosition = true;

    public static bool inputON = false;

    void Update()
    {
        if (inputON)
        {
            if (HasInput)
            {
                DragOrPickUp();
                if (boolPosition)
                {
                    startPosition = draggedObject.transform.position;
                    boolPosition = false;
                }

            }
            else
            {
                if (draggingItem)
                    DropItem();
            }
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

        if (draggingItem)
        {
            draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    draggedObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                }
            }
        }
    }

    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }

    void DropItem()
    {
        draggingItem = false;
        boolPosition = true;
        
        if (NearUser.nearCircle)
        {
            draggedObject.transform.position = NearUser.positionCircle;
            NearUser.nearCircle = false;
            NearUser.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (NearFireWall.nearCircle)
        {
            draggedObject.transform.position = NearFireWall.positionCircle;
            NearFireWall.nearCircle = false;
            NearFireWall.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (NearRouter.nearCircle)
        {
            draggedObject.transform.position = NearRouter.positionCircle;
            NearRouter.nearCircle = false;
            NearRouter.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (NearSwitch.nearCircle)
        {
            draggedObject.transform.position = NearSwitch.positionCircle;
            NearSwitch.nearCircle = false;
            NearSwitch.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (NearDNSServer.nearCircle)
        {
            draggedObject.transform.position = NearDNSServer.positionCircle;
            NearDNSServer.nearCircle = false;
            NearDNSServer.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (NearApplicationServer.nearCircle)
        {
            draggedObject.transform.position = NearApplicationServer.positionCircle;
            NearApplicationServer.nearCircle = false;
            NearApplicationServer.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (NearDataServer.nearCircle)
        {
            draggedObject.transform.position = NearDataServer.positionCircle;
            NearDataServer.nearCircle = false;
            NearDataServer.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (NearStorageServer.nearCircle)
        {
            draggedObject.transform.position = NearStorageServer.positionCircle;
            NearStorageServer.nearCircle = false;
            NearStorageServer.setActiveCircle = false;
            draggedObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else
        {
            draggedObject.transform.position = startPosition;
            draggedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
