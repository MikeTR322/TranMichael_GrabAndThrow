using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 _mousePosition;
    public Camera _POVCamera = null;

    private Vector3 GetMousePos()
    {
        return _POVCamera.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = _POVCamera.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }
}
