using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	void Start ()
	{
		HeroBase p1 = new HeroBase (12, 14, 9, 14);
		p1.addModifier (new ArmsStrength ());

		HeroBase p2 = new HeroBase (12, 14, 9, 14);
		p2.addModifier (new ArmsStrength ());

		int rounds = 0;
		string msg;
		while (true) {
			rounds++;
			attack ("P1", p1, p2);
			if (p2.isDead()) {
				msg = "P2 is dead";
				Debug.Log (msg);
				break;
			}

			attack ("P2", p2, p1);
			if (p1.isDead()) {
				msg = "P1 is dead";
				Debug.Log (msg);
				break;
			}
		}
		Debug.Log ("Rounds: " + rounds);

	}

	private void attack(string name, HeroBase p1, HeroBase p2)
	{
		string msg = name + " attack | ";
		if (!p1.tryAttack ()) {
			msg += "miss";
		} else {
			msg += "hit | ";
			if (p2.tryBlock ()) {
				msg += "blocked";
			} else {
				int dmg = p1.doDmg ();
				p2.takeDmg (dmg);
				msg += dmg;
			}
		}
		Debug.Log (msg);
	}
}
