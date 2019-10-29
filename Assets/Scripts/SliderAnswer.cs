using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAnswer : MonoBehaviour {
	public Slider nSlider;

	void IncatingAnswer(int ans)
	{
		Debug.Log(ans);
		nSlider.value = ans;
	}

	// 初期化
	void Initialize()
	{

		nSlider.value = 0;
	}

}
