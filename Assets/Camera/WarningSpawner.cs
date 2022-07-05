using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSpawner : MonoBehaviour
{
    Transform _warningSignOrigin;

    void Start()
    {
        _warningSignOrigin = transform.Find("WarningSignOrigin").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            GameObject warningSign = other.gameObject.GetComponent<Obstacle>().WarningSign;
            SpawnWarningSign(other.gameObject.transform.position.y, warningSign);
        }
    }

    void SpawnWarningSign(float atHeight, GameObject sign)
    {
        if (sign != null)
        {
            Vector3 spawnPosition = _warningSignOrigin.position;
            spawnPosition.y = atHeight;
            
            GameObject warningSign = Instantiate(sign, spawnPosition, Quaternion.identity);
            warningSign.transform.parent = transform;
        }
    }
}
