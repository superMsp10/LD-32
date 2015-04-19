using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{

	public GameObject ingame;
	public GameObject paused;
	public int chickenLeg = 0;
	public int cashLeg = 0;
	bool pause = true;
	public Text legAmount;
	public Text cashAmount;
	public Text noE;
	public Text score;
	public Text Highscore;
	public bool resetScore = false;
	private int high = 0;
	public int kills;

	public static GameM thisM;



	public Player player;

	void Awake ()
	{
		thisM = this;

	}
	void Start ()
	{

		if (resetScore) {
			PlayerPrefs.DeleteAll ();
		}
		high = PlayerPrefs.GetInt ("s", 0);
		setleg ();
		setCash ();
		resetMenu (pause);
		Highscore.text = high.ToString ();


	}


	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {
			resetMenu (!pause);
		}

		if (player == null) {
			resetMenu (true);
			score.text = getScore ().ToString ();
			Invoke ("reset", 2f);
		}

	}
	public void reset ()
	{
		Application.LoadLevel (0);
	}

	public	void tryExplode (Enemy e)
	{
		if (chickenLeg > 5) {
			e.Explode ();
			chickenLeg -= 5;
		} else {
			noE.gameObject.SetActive (true);
			Invoke ("resettext", 2f);

		}
		
	}

	void resettext ()
	{

		noE.gameObject.SetActive (false);
	}

	public void resetMenu (bool puused)
	{

		if (puused) {
			score.text = getScore ().ToString ();
			paused.SetActive (true);
			ingame.SetActive (false);
			pause = true;
		} else {

			paused.SetActive (false);
			ingame.SetActive (true);
			pause = false;

		}
	}

	public void setleg ()
	{
		chickenLeg ++;
		legAmount.text = chickenLeg.ToString ();

	}

	public void setCash ()
	{
		cashLeg ++;
		cashAmount.text = cashLeg.ToString ();
		
	}

	public int getScore ()
	{

		int i = 0;
		i = (cashLeg * 100 + kills * 100);

		if (i > high) {
			PlayerPrefs.SetInt ("s", i);

			Debug.Log (i);
		}
		return i;
		
	}

	void OnDestroy ()
	{
	}

}
