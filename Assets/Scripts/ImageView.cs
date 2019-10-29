using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageView : MonoBehaviour
{
	public Image image;

	void IndicatingImage(Sprite View)
	{
		image.sprite = View;
	}
}