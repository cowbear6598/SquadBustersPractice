using Controller.Domain;
using UnityEngine;
using VContainer.Unity;

namespace Controller.Application.Inputs
{
	public class PCInput : IInput, IInitializable
	{
		private PlayerInput playerInput;

		public void Initialize()
		{
			playerInput = new PlayerInput();
			playerInput.Enable();
		}

		public Vector2 GetMoveAxis() => playerInput.Keyboard.Movement.ReadValue<Vector2>();
	}
}