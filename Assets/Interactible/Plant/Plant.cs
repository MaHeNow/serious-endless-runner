using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable
{

    public GameObject BulletPrefab;

    private Transform _bulletStartingPosition;


    void Start()
    {
        _bulletStartingPosition = transform.Find("BulletOrigin");
    }

    public override void Activate()
    {
        Instantiate(BulletPrefab, _bulletStartingPosition.transform.position, Quaternion.identity);
    }
}
