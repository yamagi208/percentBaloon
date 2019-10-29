using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

/*
 * 【引き継ぎなどで初めてこのunityファイルのコードを見たあなたへ】
 * 
 * コードを一通り見てもらえたら分かると思うのですが、未熟なプログラミング能力＋徹夜テンションでとんでもなく面倒くさいコードになってしまいました。
 * ごめんなさい。
 * 
 * ざっくりな流れはController.csにだいたい書いてあります。
 * 
 * AnswerSliderはプレイヤーが動かすSlider、
 * newSliderは正しい正解を表示する為のSliderです。
 * AnswerSliderはHandleしかなく、newSliderは逆にHandleがありません。
 * 
 * SendMessageとGetComponent<>()~が混在しているのは完全に時間不足による杜撰な実装によるものです。バグは多分起きない。
 * 
 * Scriptsフォルダ内にある「New Animation」は決定直後のカメラの動きを指定したアニメーションファイルです。
 * AnsweringはnewSliderが0から100まで上がっていくSliderの動きを指定したアニメーションファイルです。
 * 
 */
