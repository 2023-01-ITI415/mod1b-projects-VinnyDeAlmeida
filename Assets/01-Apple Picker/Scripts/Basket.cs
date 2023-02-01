using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, select the Main Camera
        // in the Hierarchy and set its tag to MainCamera in the Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x poisition of this basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
}
