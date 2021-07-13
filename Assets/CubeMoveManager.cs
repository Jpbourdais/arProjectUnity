using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveManager : MonoBehaviour
{

    public float rotationSpeed = 27;

    private Vector2 startPosition;

    // Update is called once per frame
    void Update()
    {
        HandleSpeedChange();

        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));
    }

    private void HandleSpeedChange()
    {
        Touch[] touches = Input.touches;
        if (touches.Length >= 1)
        {
            Touch currentTouch = touches[0];
            if (currentTouch.phase == TouchPhase.Began)
            {
                startPosition = currentTouch.position;
            }
            else if (currentTouch.phase == TouchPhase.Ended)
            {
                Vector2 endPosition = currentTouch.position;
                HandleSwipe(startPosition, endPosition);
            }
        }
    }

    private void HandleSwipe(Vector2 startPosition, Vector2 endPosition)
    {
        bool isUpwardSwipe = startPosition.y < endPosition.y;
        bool isDownwardSwipe = startPosition.y > endPosition.y;

        //float swipeDistance = Vector2.Distance(startPosition, endPosition);
        if (isUpwardSwipe)
        {
            rotationSpeed += 5;
        }
        else if (isDownwardSwipe)
        {
            rotationSpeed -= 5;
        }
    }
}