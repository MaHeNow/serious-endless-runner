using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable
{

    public GameObject BulletPrefab;

    private Transform _bulletStartingPosition;
    [SerializeField] private AudioSource shootSound;


    void Start()
    {
        _bulletStartingPosition = transform.Find("BulletOrigin");
    }

    public override void Activate()
    {
        base.Activate();
        shootSound.Play();
        Instantiate(BulletPrefab, _bulletStartingPosition.transform.position, Quaternion.identity);
    }
}
