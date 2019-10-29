using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBalloons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IndicatingBalloons(int number)
	{
		this.GetComponent<Text>().text = number.ToString() + "%";
	}
}
