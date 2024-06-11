using UnityEngine;

namespace Controller
{
	public class ControllerService : IController
	{
		private readonly PlayerInput input;

		public ControllerService()
		{
			input = new PlayerInput();
			input.Enable();
		}

		public Vector2 GetMoveAxis() => input.Keyboard.Movement.ReadValue<Vector2>();
	}
}