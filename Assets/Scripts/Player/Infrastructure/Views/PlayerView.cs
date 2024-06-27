using UnityEngine;

namespace Player.Infrastructure.Views
{
	public class PlayerView : MonoBehaviour
	{
		public void Move(Vector3 move)
			=> transform.position += move;
	}
}