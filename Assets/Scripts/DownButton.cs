﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownButton : MonoBehaviour
{

	public GameObject Slider;

	//EventTriggerをアタッチしておく
	public EventTrigger _EventTrigger;

	//StopCoroutineのためにCoroutineで宣言しておく
	Coroutine PressCorutine;
	bool isPressDown = false;
	float PressTime = 2f;

	void Awake()
	{
		//PointerDownイベントの登録
		EventTrigger.Entry pressdown = new EventTrigger.Entry();
		pressdown.eventID = EventTriggerType.PointerDown;
		pressdown.callback.AddListener((data) => PointerDown());
		_EventTrigger.triggers.Add(pressdown);

		//PointerUpイベントの登録
		EventTrigger.Entry pressup = new EventTrigger.Entry();
		pressup.eventID = EventTriggerType.PointerUp;
		pressup.callback.AddListener((data) => PointerUp());
		_EventTrigger.triggers.Add(pressup);
	}

	//EventTriggerのPointerDownイベントに登録する処理
	void PointerDown()
	{
		Debug.Log("Press Start");
		//連続でタップした時に長押しにならないよう前のCoroutineを止める
		if (PressCorutine != null)
		{
			StopCoroutine(PressCorutine);
		}
		//StopCoroutineで止められるように予め宣言したCoroutineに代入
		PressCorutine = StartCoroutine(TimeForPointerDown());
	}

	//長押しコルーチン
	IEnumerator TimeForPointerDown()
	{
		//プレス開始
		isPressDown = true;

		//待機時間
		yield return new WaitForSeconds(PressTime);

		//押されたままなら長押しの挙動
		if (isPressDown)
		{
			Debug.Log("Long Press Done");

			Slider.SendMessage("PreDowning");
		}
		//プレス処理終了
		isPressDown = false;
	}

	//EventTriggerのPointerUpイベントに登録する処理
	void PointerUp()
	{
		if (isPressDown)
		{
			Debug.Log("Short Press Done");
			isPressDown = false;

			//お好みの短押し時の挙動をここに書く(無い場合は書かなくても良い)

		}
		Debug.Log("Press End");
	}
}