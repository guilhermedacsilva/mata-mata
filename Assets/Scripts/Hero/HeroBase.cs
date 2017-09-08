using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBase
{
	public int st;
	public int dx;
	public int iq;
	public int ht;
	public int hp; // health points
	public int hpNow;
	public int dmg; // min
	public int block;
	public int blockBonus;
	public int def;
	public int abilityHit;
	public int abilityShield;
	public int injured;
	private List<HeroModifier> modifiers = new List<HeroModifier>();

	public HeroBase(int st, int dx, int iq, int ht)
	{
		this.st = st;
		this.dx = dx;
		this.iq = iq;
		this.ht = ht;
		calculate ();
	}

	public void calculate()
	{
		hp = 5 * ht;
		hpNow = hp;
		dmg = getDamage(st);
		def = 1;
		abilityHit = 60 + 2 * dx;
		abilityShield = 18;
		block = abilityShield + blockBonus;
	}

	public void addModifier(HeroModifier modifier)
	{
		modifiers.Add (modifier);
		applyModifiers ();
	}

	public void applyModifiers()
	{
		foreach (HeroModifier modifier in modifiers) {
			modifier.apply (this);
		}
	}

	public bool tryAttack()
	{
		return Util.rand100() <= abilityHit - injured;
	}

	public bool tryBlock()
	{
		return Util.rand100() <= block - injured;
	}

	public int doDmg()
	{
		return dmg + Util.RANDOM.Next (3);
	}

	public void takeDmg(int dmg)
	{
		dmg -= def;
		if (dmg > 0) {
			hpNow -= dmg;
			calcInjured ();
		}
	}

	private void calcInjured()
	{
		int hp0to5 = (int) Mathf.Ceil (hpNow * 5.0f / hp);
		injured = (5 - hp0to5) * 5;
	}

	public bool isDead()
	{
		return hpNow <= 0;
	}

	public static int getDamage(int st)
	{
		return st - 7;
	}
}
