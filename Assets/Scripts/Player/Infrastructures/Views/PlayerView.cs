using Mirror;
using UnityEngine;

namespace Player.Infrastructures.Views
{
	public class PlayerView : NetworkBehaviour
	{
		public void Move(Vector3 move)
			=> transform.position += move;
	}
}