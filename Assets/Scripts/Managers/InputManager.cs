using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Camera mainCamera;
    public TileGenerator tileGenerator;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        CheckPCInput();
#else
        CheckAndroidInput();
#endif
    }

#if UNITY_EDITOR
    void CheckPCInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnTouchDown(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchUp();
        }
    }
#else
    void CheckAndroidInput()
    {
        foreach (var touch in Input.touches) 
        {
            if (touch.phase == TouchPhase.Began) 
            {
                OnTouchDown(touch.position);
            }
        }
    }
#endif
    private Vector2 ToWorldPoint(Vector3 screenPoint)
    {
        Vector3 vect = new Vector3(screenPoint.x, screenPoint.y, 0);
        Vector2 ret = mainCamera.ScreenToWorldPoint(vect);
        return ret;
    }
    private void OnTouchDown(Vector3 screenPoint)
    {
        Vector2 worldPos = ToWorldPoint(screenPoint);
        tileGenerator.Tap(worldPos.x, worldPos.y);
    }
    private void OnTouchUp()
    {
    }
}
