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



	public GameObject player;
	void Start ()
	{
		player.SetActive (true);
		setleg (0);
		setCash (0);
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

	public void setleg (int amount)
	{
		chickenLeg += amount;
		legAmount.text = chickenLeg.ToString ();

	}

	public void setCash (int amount)
	{
		cashLeg += amount;
		cashAmount.text = chickenLeg.ToString ();
		
	}
}
