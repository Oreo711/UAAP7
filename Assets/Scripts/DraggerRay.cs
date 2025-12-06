using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DraggerRay
{
		private LayerMask _layer;
		private bool _isDragging = false;
		private IDraggable _hoveredOverDraggable;

		public DraggerRay (LayerMask layer)
		{
			_layer = layer;
		}

		public IDraggable DraggedObject           {get; private set;}
		public bool       IsHoveringOverDraggable {get; private set;}

		public void Cast (Vector3 origin, Vector3 direction)
		{
			Ray ray = new Ray(origin, direction);

			if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layer))
			{
				IsHoveringOverDraggable = true;
				_hoveredOverDraggable = hit.collider.GetComponent<IDraggable>();
			}
			else
			{
				IsHoveringOverDraggable = false;
				_hoveredOverDraggable = null;
			}

			if (_isDragging)
			{
				if (Physics.Raycast(ray, out RaycastHit surfaceHit))
				{
					DraggedObject?.OnDrag(surfaceHit.point);
				}
			}
		}

		public void StartDrag ()
		{
			DraggedObject = _hoveredOverDraggable;
			DraggedObject?.OnDragStart();
			_isDragging = true;
		}

		public void EndDrag ()
		{
			_isDragging = false;
			DraggedObject?.OnDragEnd();
			DraggedObject = null;
		}
}
