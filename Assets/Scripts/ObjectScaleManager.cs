using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaleManager : MonoBehaviour
{

    public float stepScale = 1f;
    private Vector2 startPosition;

    // Update is called once per frame
    void Update()
    {
        HandleScaleChange();
    }

    private void HandleScaleChange()
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

        if (isUpwardSwipe)
        {
            transform.localScale += new Vector3(stepScale, stepScale, stepScale);
        }
        else if (isDownwardSwipe && transform.localScale.magnitude > 0)
        {
            transform.localScale -= new Vector3(stepScale, stepScale, stepScale);
        }
    }
}