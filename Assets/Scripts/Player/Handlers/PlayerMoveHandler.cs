using System;
using Controller;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player.Handlers
{
	public class PlayerMoveHandler : ITickable
	{
		[Inject] private readonly Settings    settings;
		[Inject] private readonly IController controller;
		[Inject] private readonly PlayerView  view;

		public void Tick()
		{
			var moveAxis = controller.GetMoveAxis();

			var moveDirection = new Vector3(moveAxis.x, 0, moveAxis.y);

			view.Move(moveDirection * settings.moveSpeed * Time.deltaTime);
		}

		[Serializable]
		public class Settings
		{
			public float moveSpeed;
		}
	}
}