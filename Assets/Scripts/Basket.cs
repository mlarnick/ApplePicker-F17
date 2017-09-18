using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    public Text scoreGT;

    void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get the Text component of the GameObject
        scoreGT = scoreGO.GetComponent<Text>();

        // Set the starting number of points to 0
        scoreGT.text = "0";
    }
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

        // Parse the text of the scoreGT into an int
        int score = int.Parse(scoreGT.text);

        // Add points for catching the apple
        score += 100;

        // Convert the score back to a string and display it
        scoreGT.text = score.ToString();
    }
}
