using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{

	GameObject ingame;
	GameObject paused;
	public int chickenLeg = 0;
	public Text legAmount;


	public GameObject player;
	void Start ()
	{
		player.SetActive (true);
		setleg (0);

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

		} else {

			paused.SetActive (false);
			ingame.SetActive (true);
		}
	}

	public void setleg (int amount)
	{
		chickenLeg += amount;
		legAmount.text = chickenLeg.ToString ();

	}
}
