using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAnswer : MonoBehaviour {
	public Text text;


	// Use this for initialization
	void Start () {		
		text.GetComponent<Text>().text = "";
	}
	
	void initialize()
	{
		text.GetComponent<Text>().text = "";
	}

	void indicaitingCorrectAnswer(int ans)
	{
		text.GetComponent<Text>().text = "正解："+ ans +"%";
	}

}
