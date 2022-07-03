using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{

    [SerializeField] GameObject _projectilePrefab;
    Detector _playerDetector;
    Transform _projectileOrigin;
    bool _shot = false;

    void Start()
    {
        _playerDetector = GameObject.Find("PlayerDetector").GetComponent<Detector>();
        _projectileOrigin = GameObject.Find("ProjectileOrigin").transform;

        _playerDetector.OnDetected += ShootProjectile;
    }

    void ShootProjectile()
    {
        if (!_shot)
        {
            Instantiate(_projectilePrefab, _projectileOrigin.position, Quaternion.identity);
            _shot = true;
        }
    }
}
