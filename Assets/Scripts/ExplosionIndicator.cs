using UnityEngine;

public class ExplosionIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _indicatorPrefab;

    public void Indicate (float radius, Vector3 position, float linger)
    {
        GameObject indicator = Instantiate(_indicatorPrefab, position, Quaternion.identity);
        indicator.transform.localScale = new Vector3(radius, radius, radius);

        Destroy(indicator, linger);
    }
}
