using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class Controller : MonoBehaviour
{
	public int questionNumber;
	public string questionSentence;
	public string questionImage;
	public int correctAnswer; // 正解

	public TextAsset csvFile; // CSVファイル
	public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
	public int height = 0; // CSVの行数

	public int balloons = 100;
	public int questions = 0;

	public GameObject HP;
	public GameObject QN;
	public GameObject Slider;
	public GameObject nSlider;

	public GameObject CorrectAnswerText;

	public GameObject QuestionSentenceOb;
	public GameObject QuestionImageOb;
	public Image Imageview;

	public AudioSource audioSource;

	public AudioClip bgm;
	public AudioClip riser;
	public AudioClip balloon;
	public AudioClip OrchestraHit;

	public new Animation animation;
	public Animation barAnimation;

	public static bool control = true;

	int[] QHistory = { -1, -1, -1, -1, -1, -1, -1 };

	void Start()
	{
		StringReader reader = new StringReader(csvFile.text);
		audioSource = gameObject.GetComponent<AudioSource>();

		while (reader.Peek() > -1)
		{
			string line = reader.ReadLine();
			csvDatas.Add(line.Split(',')); // リストに入れる
			height++; // 行数加算
		}

		SetQuestions();
	}

	//出題する
	//csvファイル 0...question 1...image 2...correctAnswer
	void SetQuestions()
	{
		control = true;

		nSlider.SendMessage("Initialize");
		CorrectAnswerText.SendMessage("initialize");

		audioSource.clip = bgm;
		audioSource.Play();

		questions++;
		QN.SendMessage("IndicatingQN", questions);

		//カブって無かったらbreakする
		while (true) {
			questionNumber = Random.Range(0, height);

			questionSentence = csvDatas[questionNumber][0];
			Debug.Log(csvDatas[questionNumber][1]);
			correctAnswer = System.Convert.ToInt32(csvDatas[questionNumber][2]);

			QuestionSentenceOb.SendMessage("IndicatingSentence", questionSentence);
			Imageview.sprite = Resources.Load<Sprite>("Images/" + csvDatas[questionNumber][1]);
			
			if (!dupCheck(questionNumber,questions)) break;
		}

		QHistory[questions] = questionNumber;
	}

	// Update is called once per frame
	void Update()
	{
		HP.SendMessage("IndicatingHP", balloons);
	}

	//答えを受け取って、チェックする
	IEnumerator checkAnswer(int ans)
	{
		control = false;

		audioSource.Stop();
		audioSource.PlayOneShot(riser);


		int breakBalloon = 0;

		if (ans >= correctAnswer)
		{
			breakBalloon = ans - correctAnswer;
		}
		else
		{
			breakBalloon = correctAnswer - ans;
		}

		animation.Play();
		barAnimation.Play();

		yield return new WaitForSeconds(4.5f);

		nSlider.SendMessage("IncatingAnswer", correctAnswer);
		CorrectAnswerText.SendMessage("indicaitingCorrectAnswer", correctAnswer);


		audioSource.PlayOneShot(OrchestraHit);


		yield return new WaitForSeconds(0.7f);

		if (breakBalloon != 0)
		{
			audioSource.PlayOneShot(balloon);
		}

		if (balloons - breakBalloon < 0)
		{
			balloons = 0;
		}
		else
		{
			balloons -= breakBalloon;
		}

		yield return new WaitForSeconds(3.0f);


		if (questions >= 5)
		{
			SceneManager.LoadScene("GameClear");
		}
		if (balloons <= 0)
		{
			SceneManager.LoadScene("GameOver");
		}


		SetQuestions();

	}

	bool dupCheck(int qNum,int q)
	{
		for (int i = 0; i < q; i++)
		{
			if (qNum == QHistory[i])
			{
				return true;
			}
		}
		return false;
	}

	public int getBalloons()
	{
		return balloons;
	}

	public int getAnswer()
	{
		return correctAnswer;
	}
}
