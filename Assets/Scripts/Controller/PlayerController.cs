using UnityEngine;

namespace Controller
{
	public class PlayerController : IController
	{
		private readonly PlayerInput input;

		public PlayerController()
		{
			input = new PlayerInput();
			input.Enable();
		}

		public Vector2 GetMoveAxis() => input.Keyboard.Movement.ReadValue<Vector2>();
	}
}