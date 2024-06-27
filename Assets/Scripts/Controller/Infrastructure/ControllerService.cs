using Controller.Application;
using Controller.Application.Inputs;
using Controller.Domain;
using UnityEngine;
using VContainer;

namespace Controller.Infrastructure
{
	public class ControllerService : IController
	{
		[Inject] private readonly IInput input;

		public Vector2 GetMoveAxis() => input.GetMoveAxis();
	}
}