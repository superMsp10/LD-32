using UnityEngine;
using System.Collections;

public class level : MonoBehaviour
{
	public bool turnR = true;
	public int offSet;
	public Transform startPos;
	public int levelsG;
	public GameObject[] lev;
	public 	static level thisLevel;
	int difficulty;

	void Awake ()
	{
		thisLevel = this;
	}
	void Start ()
	{
		generateLevels (2);
	
	}
	

	public void generateLevels (int n)
	{
		GameObject newLev;
		for (int i =0; i<n; i++) {

			int chooselev = 20 / lev.Length;
			difficulty = levelsG / chooselev;
			if (difficulty < lev.Length) {
				newLev = lev [Random.Range (0, difficulty)];
			} else {
				newLev = lev [Random.Range (0, lev.Length)];

			}



			Vector3 pos = startPos.position;
			pos.y += (levelsG * offSet); 
			GameObject g = (GameObject)Instantiate (newLev, pos, Quaternion.identity);
			if (turnR) {
				g.transform.localScale = new Vector3 (g.transform.localScale.x * -1, g.transform.localScale.y, g.transform.localScale.z);
				turnR = false;
			} else {
				turnR = true;
			}

			g.transform.parent = gameObject.transform;
			levelsG++;

		}
	}
}
