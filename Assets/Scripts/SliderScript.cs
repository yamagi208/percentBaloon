using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {
	public Slider slider;
	public GameObject controller;
	public GameObject balloons;
	
	int p;
	int prediction = 0;
	int time;
	// Use this for initialization
	void Start ()
	{
		p = 0;
		slider.value = prediction;
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {

		slider.value = prediction;

		if (Controller.control)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow) && prediction < 100)
			{
				prediction++;
			}

			if (Input.GetKey(KeyCode.RightArrow) && prediction < 100)
			{
				p++;
				if (p >= 20)
				{
					prediction++;
				}
			}

			if (Input.GetKeyUp(KeyCode.RightArrow) && prediction < 100)
			{
				p = 0;
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow) && prediction > 0)
			{
				prediction--;
			}

			if (Input.GetKey(KeyCode.LeftArrow) && prediction > 0)
			{
				p++;
				if (p >= 20)
				{
					prediction--;
				}
			}

			if (Input.GetKeyUp(KeyCode.LeftArrow) && prediction > 0)
			{
				p = 0;
			}

			if (Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				controller.SendMessage("checkAnswer", prediction);
			}
		}

		balloons.SendMessage("IndicatingBalloons", prediction);
	}

	void PreUp()
	{
		if (prediction < 100)
		{
			prediction++;
		}
	}

	void PreUp10()
	{
		if (prediction < 90)
		{
			prediction += 10;
		}
		else
		{
			prediction = 100;
		}
	}

	void PreDown()
	{
		if (prediction > 0)
		{
			prediction--;
		}
	}

	void PreDown10()
	{
		if (prediction > 10)
		{
			prediction -= 10;
		}
		else
		{
			prediction = 0;
		}
	}

	// 初期化
	void Initialize()
	{
		prediction = 50;
	}

	public int getP()
	{
		return prediction;
	}
}

//viewquestionを呼んだら表示、hiddenquestionを呼んだら隠す
