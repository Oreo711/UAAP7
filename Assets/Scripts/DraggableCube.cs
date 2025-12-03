using UnityEngine;
using UnityEngine.Serialization;


public class DraggableCube : MonoBehaviour, IDraggable
{
    [SerializeField] private float _dragScaleShift;

    public void OnDragStart ()
    {
        transform.localScale *= _dragScaleShift;
    }

    public void OnDrag (Vector3 point)
    {
        transform.position = new Vector3(point.x, transform.position.y, point.z);
    }

    public void OnDragEnd ()
    {
        transform.localScale /= _dragScaleShift;
    }
}
