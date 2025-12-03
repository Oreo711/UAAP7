using System;
using UnityEngine;
using UnityEngine.Serialization;


public class ExplosionRay
{
    private float _explosionRadius;
    private LayerMask _surface;
    private AudioSource _explosionSound;
    private ExplosionIndicator _explosionIndicator;
    private float _indicatorLinger;

    public ExplosionRay (float explosionRadius, LayerMask surface, AudioSource explosionSound, ExplosionIndicator explosionIndicator, float indicatorLinger)
    {
        _explosionRadius    = explosionRadius;
        _surface            = surface;
        _explosionSound     = explosionSound;
        _explosionIndicator = explosionIndicator;
        _indicatorLinger    = indicatorLinger;
    }

    public void Cast (Vector3 origin, Vector3 direction)
    {
        Ray ray = new Ray(origin, direction);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _surface))
        {

            Collider[] hitObjects = Physics.OverlapSphere(hit.point, _explosionRadius);

            foreach (Collider hitObject in hitObjects)
            {
                if (hitObject.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(1000, hit.point, _explosionRadius);
                }
            }

            _explosionSound.transform.position = hit.point;
            _explosionSound.Play();

            _explosionIndicator.Indicate(_explosionRadius, hit.point, _indicatorLinger);
        }
    }
}
