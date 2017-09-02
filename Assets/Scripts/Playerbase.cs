using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbase : MonoBehaviour {

	/*
		have a reference to the player object;
		if base is owned by player, start position is 0,0
		if base is owned by player2, start position is 9,0
		
	*/	


	public Coord position;

	// Use this for initialization
	void Start () {
		position = new Coord(0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider coll){
		Services.SceneStackManager.Swap<WinScreen>();
	}

	
}
