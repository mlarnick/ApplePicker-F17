﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();
		for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
	}

    public void AppleDestroyed()
    {
        // Destroy all of the falling Apples
        GameObject[] tApplearray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tApplearray)
        {
            Destroy(tGO);
        }

        // Destroy one of the Baskets
        // Get the index of the last basket in BasketList
        int basketIndex = basketList.Count - 1;

        // Get a reference to the Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];

        // Remove the Basket from the List and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
