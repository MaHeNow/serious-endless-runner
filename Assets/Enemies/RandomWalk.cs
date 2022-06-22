using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{

    public float movementSpeed = 2;
    public float MinimumTurningTime = 1;
    public float MaximumTurningTime = 3;
    private float _turningTime;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTurningTime();
        this._spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));

        this._turningTime -= Time.deltaTime;
        if (this._turningTime < 0) {
            SetRandomTurningTime();
            TurnAround();
        }
    }

    void SetRandomTurningTime()
    {
        this._turningTime = Random.Range(MinimumTurningTime, MaximumTurningTime);
    }

    void TurnAround()
    {
            movementSpeed = -movementSpeed;
            this._spriteRenderer.flipX = !this._spriteRenderer.flipX;
    }
}
