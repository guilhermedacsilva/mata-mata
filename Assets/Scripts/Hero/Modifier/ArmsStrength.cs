using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsStrength : HeroModifier
{
	override public void apply(HeroBase hero)
	{
		hero.dmg = HeroBase.getDamage (hero.st + 2);
	}
}
