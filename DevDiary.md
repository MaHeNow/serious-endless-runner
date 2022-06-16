# Developer Diary

## Participants

Mario Nowak, 

## Task 1

### 1.1

First, we created a GitHub repository to collaboratively work on the project. Next, we installed Unity Hub and created a 2D project for our game using the 2D template. We went with editor version `2020.3.35f1` as it was the one used in the lecture videos. 

### 1.2

We found an asset pack called [Jungle Pack](https://jesse-m.itch.io/jungle-pack) on `itch.io` and imported the sprite sheets for the player, background and terrain into our project. Next, we wanted to create a player game object with a walking animation. For that, we used the built-in sprite editor to splice the sprite sheet into individual frames. Then we dragged the frames into the editor, creating a run animation and an animation controller. Finally, we added an `Animator` component to the player game object and assigned the animation controller to it. With that, the player started playing the walking animation once we started the game. 

### 1.3

In order to move the character, we created a `PlayerController.cs` script:

```cs
// PlayerController.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D Transform;
    public float MovementSpeed = 5;

    void Start()
    {
        Transform = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Transform.velocity = new Vector2(MovementSpeed, 0);
    }
}
```

The script fetches the player's `Rigidbody2D` component and sets it's horizontal velocity to be a constant value greater zero. This way, the player moves to the right.
Additionally, we constrained the the player's movement by disabling rotation around the Z axis.

### 1.4

To ensure that the camera is "following" the player, we gave it a `CameraFollow` script. The script takes in a transform and in every `Update` call, it sets it's own transform to the given one:

```cs
public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public Vector2 cameraOffset = new Vector2(4.0f, 2.0f);

    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + cameraOffset.x , cameraOffset.y, this.transform.position.z);
    }
}
```

### 1.5

While implementing the player jump we realized that our way of moving the player may not be appropriate. We changed the movement to be handled in a `FixedUpdate` call via a `translate`:

```cs
void FixedUpdate()
{
    transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
}
```

We use the `Update` method to check for user input:

```cs
void Update()
{
    if(Input.GetKeyDown(KeyCode.Space) && this._onGround) {
        this._rigidbody.AddForce(new Vector2(0, this._jumpForce), ForceMode2D.Impulse);
    } 
}
```

To prevent the player from jumping multiple times in the air, we added an extra condition that checks if the player is on the ground.

### 1.6

TODO: 

### 1.7

TODO:
