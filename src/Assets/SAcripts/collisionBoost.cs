using UnityEngine;
using System.Collections;

public class collisionBoost : MonoBehaviour
{
	public int MultiplierX;
	public int MultiplierY;
	public float boostAmount;
	public Vector2 dir;
	int  amount = 0;


	public void  boost (Rigidbody2D target)
	{

		float thisX = target.velocity.x / 2;
		float thisY = (target.velocity.y / 2) * -1;
		Vector2 tagetVeloMulti = new Vector2 (thisX * MultiplierX, thisY * MultiplierY);
		Vector2 boost = new Vector2 (dir.x * boostAmount, dir.y * (boostAmount));
		Vector2 force = (tagetVeloMulti + boost);
		target.AddForceAtPosition (force, transform.position);
		if (amount < 1) {
			level.thisLevel.generateLevels (1);
		}
		amount++;
	}

}
