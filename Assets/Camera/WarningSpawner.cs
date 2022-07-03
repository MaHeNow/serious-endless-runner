using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSpawner : MonoBehaviour
{
    [SerializeField] GameObject _warningSignPrefab;
    Transform _warningSignOrigin;

    void Start()
    {
        _warningSignOrigin = GameObject.Find("WarningSignOrigin").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SpawnWarningSign(other.gameObject.transform.position.y);
        }
    }

    void SpawnWarningSign(float atHeight)
    {
        Vector3 spawnPosition = _warningSignOrigin.position;
        spawnPosition.y = atHeight;
        
        GameObject warningSign = Instantiate(_warningSignPrefab, spawnPosition, Quaternion.identity);
        warningSign.transform.parent = transform;
    }
}
