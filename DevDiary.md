# Developer Diary

## Participants

Mario Nowak, 

## Task 1

### 1.1

First, we created a GitHub repository to collaboratively work on the project. Next, we installed Unity Hub and created a 2D project for our game using the 2D template. We went with editor version `2020.3.35f1` as it was the one used in the lecture videos. 

### 1.2

Since we weren't sure what assets to use, we went with a few simple, differently colored boxes. We created the textures using `Aseprite`.

To recognize if the player is moving or not we added a very simple debug background.

After adding the textures and placing them in the scene tree, our main scene looked like this:

![](/DevDiaryAssets/FistScene.png)

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

To ensure that the camera is "following" the player, we added it as a child. This way, the camera always focuses the player, mo matter its movement.
