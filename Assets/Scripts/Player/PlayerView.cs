using Mirror;
using UnityEngine;

namespace Player
{
	public class PlayerView : NetworkBehaviour
	{
		public void Move(Vector3 move)
			=> transform.position += move;
	}
}