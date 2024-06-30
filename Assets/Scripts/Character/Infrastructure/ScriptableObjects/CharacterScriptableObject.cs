using UnityEngine;

namespace Character.Infrastructure.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Character", menuName = "Data/Character")]
	public class CharacterScriptableObject : ScriptableObject
	{
		[SerializeField]
		private Domain.Character character;
	}
}