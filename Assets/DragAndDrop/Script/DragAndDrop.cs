using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 _mousePosition;

    public bool _canSnapToPosition = false;
    public List<Transform> _snapPoints;
    public float _snapRange = 0.5f;
    public Camera _POVCamera = null;

    private void Update()
    {
        if (_canSnapToPosition)
        {
            SnapToPosition();
        }
    }

    //Get mouse position on Screen in Camera View
    private Vector3 GetMousePos()
    {
        return _POVCamera.WorldToScreenPoint(transform.position);
    }

    //When mouse clicks on an object with the DragAndDrop script
    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - GetMousePos();
    }

    //The object follows the mouse position
    private void OnMouseDrag()
    {

        transform.position = _POVCamera.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }

    private void SnapToPosition()
    {
        foreach(Transform point in _snapPoints)
        {
            if(Vector2.Distance(point.position,transform.position) <= _snapRange)
            {
                transform.position = point.position;
                return;
            }
        }
    }
}
