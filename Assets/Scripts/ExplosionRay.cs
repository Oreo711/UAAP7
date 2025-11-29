using System;
using UnityEngine;
using UnityEngine.Serialization;


public class ExplosionRay : MonoBehaviour
{
    [SerializeField] private float       _explosionRadius;
    [SerializeField] private LayerMask   _surface;
    [SerializeField] private AudioSource _explosionSound;
    [SerializeField] private GameObject  _explosionIndicator;
    [SerializeField] private float       _indicatorLinger;

    private void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _surface))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Collider[] hitObjects = Physics.OverlapSphere(hit.point, _explosionRadius);

                foreach (Collider hitObject in hitObjects)
                {
                    if (hitObject.TryGetComponent(out Rigidbody rigidbody))
                    {
                        rigidbody.AddExplosionForce(1000, hit.point, _explosionRadius);

                    }
                }

                GameObject indicator = Instantiate(_explosionIndicator, hit.point, Quaternion.identity);
                indicator.transform.localScale = new Vector3(_explosionRadius, _explosionRadius, _explosionRadius);

                _explosionSound.transform.position = hit.point;
                _explosionSound.Play();

                Destroy(indicator, _indicatorLinger);
            }
        }
    }
}
