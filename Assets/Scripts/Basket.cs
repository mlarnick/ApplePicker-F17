using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2d = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2d.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);

        // Move the x position of this basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;
	}

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
    }
}
