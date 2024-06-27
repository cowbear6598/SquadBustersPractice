using Mirror;
using UnityEngine;

namespace Player.Infrastructure.Views
{
	public class PlayerView : NetworkBehaviour
	{
		public void Move(Vector3 move)
			=> transform.position += move;
	}
}