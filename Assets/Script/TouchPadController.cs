using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPadController : MonoBehaviour {

    private RectTransform _touchPad;
    private int _touchId = -1;
    private Vector3 _startPos = Vector3.zero;
    public float _dragRadius = 60f;
    public PlayerController _player;
    private bool _buttonPressed = false;

	// Use this for initialization
	void Start () {
        _touchPad = GetComponent<RectTransform>();

        _startPos = _touchPad.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        HandleTouchInput();
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        HandleInput(Input.mousePosition);
#endif
    }

    private void HandleTouchInput()
    {
        int i = 0;

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                i++;
                Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);

                if (touch.phase == TouchPhase.Began)
                {
                    if (touch.position.x <= (_startPos.x + _dragRadius))
                    {
                        _touchId = i;
                    }
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (_touchId == i)
                    {
                        HandleInput(touchPos);
                    }
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    if (_touchId == i)
                    {
                        _touchId = -1;
                    }
                }


            }
        }

    }

    public void ButtonDown()
    {
        _buttonPressed = true;
        Debug.Log("buttonPressed");
    }
    public void ButtonUp()
    {
        _buttonPressed = false;
        Debug.Log("buttonReleased");

        HandleInput(_startPos);

    }

    private void HandleInput(Vector3 input)
    {
        if (_buttonPressed)
        {
            Vector3 diffVector = (input - _startPos);
            if (diffVector.sqrMagnitude > _dragRadius * _dragRadius)
            {
                diffVector.Normalize();
                _touchPad.position = _startPos + diffVector * _dragRadius;
            }
            else
            {
                _touchPad.position = input;
            }
            
        }
        else
        {
            _touchPad.position = _startPos;
        }

        Vector3 diff = _touchPad.position - _startPos;
        Vector2 normDiff = new Vector3(diff.x / _dragRadius, diff.y / _dragRadius);

        if (_player != null)
        {
            _player.Move(normDiff);
        }


    }
}
