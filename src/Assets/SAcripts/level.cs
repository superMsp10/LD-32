using UnityEngine;
using System.Collections;

public class level : MonoBehaviour
{
	public bool turnR = true;
	public int offSet;
	public Transform startPos;
	public int levelsG;
	public GameObject lev;
	public 	static level thisLevel;

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

		for (int i =0; i<n; i++) {
			Vector3 pos = startPos.position;
			pos.y += (levelsG * offSet); 
			GameObject g = (GameObject)Instantiate (lev, pos, Quaternion.identity);
			if (turnR) {
				g.transform.localScale = new Vector3 (-1, g.transform.localScale.y, g.transform.localScale.z);
				turnR = false;
			} else {
				g.transform.localScale = new Vector3 (1, g.transform.localScale.y, g.transform.localScale.z);
				turnR = true;
			}

			g.transform.parent = gameObject.transform;
			levelsG++;

		}
	}
}
