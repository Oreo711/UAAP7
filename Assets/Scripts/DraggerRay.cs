using UnityEngine;
using UnityEngine.Serialization;


public class DraggerRay : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layer))
        {
            if (Input.GetMouseButton(0))
            {
                hit.collider.transform.position = new Vector3(hit.point.x, hit.collider.transform.position.y, hit.point.z);
            }
        }
    }
}
