using System;

namespace Character.Domain
{
	[Serializable]
	public class Character
	{
		public Rarity Rarity;
		public string Name;
		public int    Attack;
		public float  AttackSpeed;
		public int    Health;
	}
}