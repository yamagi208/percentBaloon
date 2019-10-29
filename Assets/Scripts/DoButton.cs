using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoButton : MonoBehaviour {
	public GameObject Slider;
	public GameObject EventSystem;

	void Push()
	{
		if (Controller.control)
		{
			SliderScript sl = Slider.GetComponent<SliderScript>();
			EventSystem.SendMessage("checkAnswer", sl.getP());
		}
	}
}
