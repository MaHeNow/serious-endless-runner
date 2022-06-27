using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public delegate void PlayerInside(Interactable self);
    public static event PlayerInside OnPlayerInside;
    public delegate void PlayerExited(Interactable self);
    public static event PlayerExited OnPlayerExited;

    public float LoadingTime = 1;
    public float CurrentLoadingTime = 0;
    public bool Used = false;

    private bool _loading;


    void Start() {}

    void Update()
    {
        if (_loading) {
            CurrentLoadingTime += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerInside(this);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerExited(this);
            Trigger();
        }
    }


    public virtual void Activate()
    {
        // Hook Function
    }
    
    public void Load()
    {
        if (!Used)
        {
            _loading = true;
        }
    }

    public void Trigger()
    {
        _loading = false;
        if (CurrentLoadingTime > LoadingTime && !Used)
        {
            Activate();
            Used = true;
        }
        ResetLoadingTime();
    }

    private void ResetLoadingTime()
    {
        CurrentLoadingTime = 0;
    }

}
