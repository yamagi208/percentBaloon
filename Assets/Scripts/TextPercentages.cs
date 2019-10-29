using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPercentages : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IndicatingHP(int HP)
	{
		GetComponent<Text>().text = "残り\n" + HP.ToString() + "個";
	}
}
