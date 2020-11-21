using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPhysics : MonoBehaviour
{
    public GameObject green;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
