# Tag based collission implementation for Unity.

About this implementation so it's easier to integrate ==>

## GameObjects in the scene (aside from camera and light)
* floor with a box collider (and a phyisc material for some friction but don't worry about this one)
* A sphere with a tag of green, that's a sphere collider and ridibody. ** Make sure isTrigger is unchecked!! **
* Same as above except with a red tag
* A wall (a cube primitive) with a box collider

The script attached to the sphere is just for movement. But the juicy part is in the `WallPhysics.cs` file

## About the code

This is what's actually important

```
    void OnCollisionEnter(Collision collision)
    {
        green = GameObject.FindGameObjectWithTag("Green");
        wall = GameObject.Find("Wall");
        //if(collision.collider.CompareTag("Green") || collision.collider.CompareTag("Red"))
        //{
        Debug.Log(collision.collider.tag + " hit the wall");
        //}
        if (collision.collider.CompareTag("Green"))
        {
            //Destroy(green.GetComponent<SphereCollider>()); //Stupid way to do this
            //Chad way to do this
            Physics.IgnoreCollision(green.GetComponent<SphereCollider>(), wall.GetComponent<BoxCollider>() );
        }

    }
```

This method detects, when colissions happen. First we find the GameObjects with the tag green, and then we find a specific object by its name: (in this case) Wall.
* `Debug.Log` is just there for debugging
* Now when a collission happens, we check if the colliders tag is green.

Then we use the Physics method of Ignore collission to ignore the collission that's happening between the wall and game Object with the tag 'green'
