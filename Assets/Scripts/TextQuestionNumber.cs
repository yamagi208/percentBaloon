using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextQuestionNumber : MonoBehaviour {

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void IndicatingQN(int questions)
	{
		Debug.Log("indicatingQN受け取り");
		if (questions < 5)
		{
			GetComponent<Text>().text = questions.ToString() + "問目";
		}
		else if(questions == 5)
		{
			GetComponent<Text>().text = "最終問題";
		}
	}
}
