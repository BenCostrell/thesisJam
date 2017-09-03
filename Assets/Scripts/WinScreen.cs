using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : Scene<TransitionData> {
	
	public Text winText;				
	// Use this for initialization

	void Start () {
   

	}
	
	internal override void OnEnter (TransitionData data)
	{  
		Services.EventManager.Register<ButtonPressed>(StartGame);
		winText.text = "Player " + data.winner + " won!";
	}
	// Update is called once per frame
	void Update () {
	}

	void StartGame(ButtonPressed e){
		Services.EventManager.Unregister<ButtonPressed>(StartGame);
		Services.SceneStackManager.Swap<Main>();
	}



}
