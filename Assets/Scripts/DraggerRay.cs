using UnityEngine;

public class DraggerRay
{
		private LayerMask  _layer;
		private bool       _isDragging = false;

		public DraggerRay (LayerMask layer)
		{
			_layer = layer;
		}

		public  IDraggable LastDraggedObject {get; private set;}

		public void Cast (Vector3 origin, Vector3 direction)
		{
			Ray ray = new Ray(origin, direction);

			if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layer))
			{
				IDraggable draggable = hit.collider.GetComponent<IDraggable>();

				LastDraggedObject = draggable;

				draggable?.OnDrag(hit.point);
			}
		}

}
