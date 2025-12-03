using UnityEngine;

public interface IDraggable
{
    void OnDragStart ();

    void OnDrag (Vector3 point);

    void OnDragEnd ();
}
