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
	public static GameM thisM;



	public GameObject player;

	void Awake ()
	{
		thisM = this;

	}
	void Start ()
	{
		player.SetActive (true);
		setleg ();
		setCash ();
		resetMenu (pause);


	}


	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {
			resetMenu (!pause);
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
}
