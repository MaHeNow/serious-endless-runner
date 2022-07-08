using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class Lift : Interactable
{
    public float TransitionDuration = 1;
    private Vector3 _endPosition;
    [SerializeField] private AudioSource appearSound;

    // Start is called before the first frame update
    void Start()
    {
       _endPosition = transform.Find("EndPosition").GetComponent<Transform>().position;
    }


    public override void Activate()
    {
        base.Activate();

        System.Action<ITween<Vector3>> updatePosition = (t) =>
        {
            gameObject.transform.position = t.CurrentValue;
        };

        appearSound.Play();
        gameObject.Tween("Move", transform.position, _endPosition, TransitionDuration, TweenScaleFunctions.CubicEaseInOut, updatePosition);
    }
}
