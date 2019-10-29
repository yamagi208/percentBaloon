using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSentence : MonoBehaviour {

	void IndicatingSentence(string Sentence)
	{
		this.GetComponent<Text>().text = Sentence ;
	}
}
