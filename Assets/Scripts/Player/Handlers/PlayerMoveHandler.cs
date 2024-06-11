﻿using System;
using Controller;
using TimeProvider;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player.Handlers
{
	public class PlayerMoveHandler : ITickable
	{
		[Inject] private readonly Settings      settings;
		[Inject] private readonly IController   controller;
		[Inject] private readonly ITimeProvider timeProvider;
		[Inject] private readonly PlayerView    view;

		public void Tick()
		{
			var moveAxis = controller.GetMoveAxis();

			var moveDirection = new Vector3(moveAxis.x, 0, moveAxis.y);

			view.Move(moveDirection * settings.moveSpeed * timeProvider.GetDeltaTime());
		}

		[Serializable]
		public class Settings
		{
			public float moveSpeed;
		}
	}
}