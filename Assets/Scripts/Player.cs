using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _explosionSound;
    [SerializeField] private ExplosionIndicator _explosionIndicator;

    private DraggerRay _draggerRay;
    private ExplosionRay _explosionRay;

    private void Awake ()
    {
        _draggerRay = new DraggerRay(LayerMask.GetMask("Draggable"));
        _explosionRay = new ExplosionRay(2f, LayerMask.GetMask("Ground"), _explosionSound, _explosionIndicator, 1f);
    }

    private void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            _draggerRay.Cast(Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
        }

        if (Input.GetMouseButtonDown(0) && _draggerRay.IsHoveringOverDraggable)
        {
            _draggerRay.StartDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _draggerRay.EndDrag();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _explosionRay.Cast(Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
        }
    }
}
