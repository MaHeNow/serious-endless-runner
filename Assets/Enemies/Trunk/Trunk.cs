using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{

    [SerializeField] GameObject _projectilePrefab;
    PlayerDetector _playerDetector;
    Transform _projectileOrigin;
    bool _shot = false;

    void Start()
    {
        _playerDetector = GameObject.Find("PlayerDetector").GetComponent<PlayerDetector>();
        _projectileOrigin = GameObject.Find("ProjectileOrigin").transform;

        _playerDetector.OnDetectedPlayer += ShootProjectile;
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
